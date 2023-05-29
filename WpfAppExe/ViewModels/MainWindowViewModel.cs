using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppExe.Core;
using WpfAppExe.Views;

namespace WpfAppExe.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand ClickCommand { get; set; } = new ReactiveCommand();

        public ReactiveCommand ClickCommand1 { get; set; } = new ReactiveCommand();

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            ClickCommand.Subscribe(o =>
            {
                ComponentWindow componentWindow = new ComponentWindow();
                if(componentWindow.DataContext is ComponentWindowViewModel vm)
                {
                    vm.SelectedTabIndex.Value = Convert.ToInt32((o as string));
                }
                componentWindow.ShowDialog();
            });

            ClickCommand1.Subscribe(o =>
            {
                int value = 1234;
                long commonSecond = 0;
                long objectSecond = 0;
                long genericSecond = 0;

                Stopwatch stopwatch1 = new Stopwatch();
                Stopwatch stopwatch2 = new Stopwatch();
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch1.Start();
                for(int i = 0; i < 100000000; i++)
                {
                    Test(value);
                }
                stopwatch1.Stop();
                commonSecond = stopwatch1.ElapsedMilliseconds;

                stopwatch2.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    TestObject(value);
                }
                stopwatch2.Stop();
                objectSecond = stopwatch2.ElapsedMilliseconds;

                stopwatch3.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    Test<int>(value);
                }
                stopwatch3.Stop();
                genericSecond = stopwatch3.ElapsedMilliseconds;

                MessageBox.Show(commonSecond.ToString()+"\n"+ objectSecond.ToString() + "\n" + genericSecond.ToString());

                Test1<Stopwatch>(new Stopwatch());

                Class1 class1 = new Class1(3);

                Test2<Class1>(class1);
            });

        }

        #region 泛型
        private void Test(int a)
        {

        }

        private void TestObject(object a)
        {

        }

        private void Test<T>(T a)
        {

        }

        //限制了参数的类型，必须是class
        private void Test1<T>(T a) where T : class
        {

        }

        //new表示参数必须有无参构造函数
        private void Test2<T>(T a)where T : new()
        {

        }
        #endregion
    }

    public class Class1
    {
        public Class1(){}
        public Class1(int a){}
    }

    #region 依赖属性和INotifyPropertyChanged
    public class DpClass : DependencyObject
    {
        public string Name
        {
            get => (string)GetValue(NameProperty); 
            set => SetValue(NameProperty, value);
        }

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(DpClass),new PropertyMetadata(""));
    }

    public class NpClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }
    }

    public class BindableClass : BindableBase
    {
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value);}
    }
    #endregion
}
