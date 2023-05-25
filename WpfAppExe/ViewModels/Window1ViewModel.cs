using Npgsql;
using Prism.Events;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.TinyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WpfAppExe.Core;
using WpfAppExe.Event;
using WpfAppExe.Infrastructure;
using WpfAppExe.Models;
using WpfAppExe.Utils;

namespace WpfAppExe.ViewModels
{
    public class Window1ViewModel : ViewModelBase
    {
        private DispatcherTimer searchTimer;

        private IEventAggregator _aggregator;

        public ICollectionView listCollectionView { get; set; }

        //public ListCollectionView listView { get; set; }

        public ReactiveCollection<Person> List { get; set; } = new ReactiveCollection<Person>();

        public ReactivePropertySlim<bool> IsDisplay { get; set; } = new ReactivePropertySlim<bool>();

        public ReactivePropertySlim<Person> SelectedPerson { get; set; } = new ReactivePropertySlim<Person>();

        public ReactiveCommand PreviewMouseRightButtonDownCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand EditCommand { get; set; } = new ReactiveCommand();

        public ReactiveCommand<string> EditCommand1 { get; set; } = new ReactiveCommand<string>();
        public InteractionRequest<CommonNotification> ShowWindow1Edit { get; set; } = new InteractionRequest<CommonNotification>();

        public ReactivePropertySlim<string> Title1 { get; set; } = new ReactivePropertySlim<string>("标题1");
        public ReactivePropertySlim<string> Title2 { get; set; } = new ReactivePropertySlim<string>("标题2");

        public ReactivePropertySlim<string> SearchName { get; set; } = new ReactivePropertySlim<string>("");
        public ReactivePropertySlim<string> SearchAddress { get; set; } = new ReactivePropertySlim<string>("");
        public ReactivePropertySlim<string> SearchContact { get; set; } = new ReactivePropertySlim<string>("");

        public ReactiveCommand SerachCommand { get; set; } = new ReactiveCommand();

        /// <summary>
        /// データロード動作
        /// </summary>
        public ReactivePropertySlim<int> WorkCounter { get; set; } = new ReactivePropertySlim<int>(0);

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
            listCollectionView=CollectionViewSource.GetDefaultView(List);
            listCollectionView.Filter = DataListFilter;
        }

        protected override void InitData()
        {
            base.InitData();
            PrepareData().ForEach(o =>
            {
                List.Add(o);
            });
            System.Diagnostics.Debug.WriteLine(ExtendParameter);
            
            string str = "555";
            SSSS(str);
            System.Diagnostics.Debug.WriteLine(str);

            SSSS(ref str);
            System.Diagnostics.Debug.WriteLine(str);

            string ConStr = @"PORT=5432;DATABASE=APPLICATION;HOST=192.168.0.169;PASSWORD=postgres;USER ID=postgres";
            NpgsqlConnection SqlConn = new NpgsqlConnection(ConStr);

            DataSet dataSet = new DataSet();
            string sql = "SELECT * FROM p000100.problem";
            NpgsqlDataAdapter ad = new NpgsqlDataAdapter(sql, SqlConn);
            ad.Fill(dataSet);
        }

        protected override void NotificationInit()
        {
            base.NotificationInit();
            if(Notification.Content is string sss)
            {
                return;
            }

        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            this.searchTimer = new DispatcherTimer();
            this.searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            this.searchTimer.Tick += SearchTimer_Tick;

            PreviewMouseRightButtonDownCommand = IsDisplay.Select(o => 1 < 4).ToReactiveCommand();

            EditCommand1 = IsDisplay.Select(o => 1 <= 3).ToReactiveCommand<string>();

            PreviewMouseRightButtonDownCommand.Subscribe(o =>
            {
                IsDisplay.Value = false;
                IsDisplay.Value = true;

                VisualTreeHelperWrapperUtility visualTreeHelper = new VisualTreeHelperWrapperUtility();
                if(o is MouseButtonEventArgs arg && arg.OriginalSource is DependencyObject dp)
                {
                    if(visualTreeHelper.FindAncestor<DataGridCell>(dp) is DataGridCell dataGridRow)
                    {
                        SelectedPerson.Value = dataGridRow.DataContext as Person;
                    }
                }
                //if(visualTreeHelper.FindAncestor<DataGridCell>(dp) is DataGridCell)

            });

            EditCommand.Subscribe(o => {
                IsDisplay.Value = false;
                //ShowWindow1Edit.Raise(new CommonNotification());
            });

            SelectedPerson.Subscribe(o =>
            {
            });

            SerachCommand.Subscribe(o => {
                this.searchTimer.Start();
            });

        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            listCollectionView.Refresh();
            this.searchTimer.Stop();
        }

        private List<Person> PrepareData()
        {
            List<Person> data = new List<Person>();
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                data.Add(new Person()
                {
                    Name = i.ToString() + "号",
                    Age = random.Next(15, 48),
                    Address = i.ToString() + "街区",
                    Contact = (10000 + i).ToString()
                });
            }
            var list1 = data.FindAll(x=>x.Age>46);
            var list2 = data.Where(x => x.Age > 46).ToList();
            var list3 = data.Select(x => x.Age).ToList();
            var list4 = data.All(x => x.Age > 46);
            var list5 = data.Any(x => x.Age > 46);
            var list6 = data.GroupBy(x => x.Age).ToDictionary(x => x.Key, x => x.ToList());
            var list7 = data.Find(x => x.Age > 46);
            var list8 = data.Union(data).ToList();
            var list9 = data.OrderBy(x => x.Age).ToList();
            var list10 = data.Append(new Person { Age =0,Address="3",Contact="34",Name="333"}).ToList();
            Person p = new Person { Age = 3, Name = "3", Contact = "33", Address = "4" };
            data.Add(p);
            var list11 = data;
            return data;
        }

        private void SSSS(string s)
        {
            s += "55555";
        }

        private void SSSS(ref string s)
        {
            s += "55555";
        }

        private bool DataListFilter(object item)
        {
            if(item is Person person && person!=null)
            {
                if (person.Name.Contains(SearchName.Value) &&
                    person.Address.Contains(SearchAddress.Value) &&
                    person.Contact.Contains(SearchContact.Value))
                    return true;
                return false;
            }
            return true;
        }

        private void PubSubEventMessage()
        {
            MessageModel message = new MessageModel
            {
                Code = 200,
                Message = "操作成功",
                Data = "{}"
            };
            _aggregator.GetEvent<MessageEvent>().Publish(message);
        }


    }

    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();

        public event NumManipulationHandler ChangeNum;

        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("event fire"+": "+value);
            }
        }

        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }

    public class subscribEvent{
        public void printf()
        {
            System.Diagnostics.Debug.WriteLine("event fire");
        }
    }

}
