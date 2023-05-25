using DataBase.DbDto;
using Newtonsoft.Json;
using Npgsql;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Unity;
using WpfAppExe.ActionBase;
using WpfAppExe.Core;
using WpfAppExe.Infrastructure;
using WpfAppExe.Manager;
using WpfAppExe.Models;
using WpfAppExe.Views;

namespace WpfAppExe.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        #region varible
        #endregion

        #region Command
        public ReactiveCommand LoginCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand PreviewKeyDownCommand { get; set; } = new ReactiveCommand();
        #endregion

        #region Property
        public ReactivePropertySlim<string> UserName { get; set; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Password { get; set; } = new ReactivePropertySlim<string>();
        #endregion

        #region InteractionRequest
        public InteractionRequest<CommonNotification> ShowWindow1Request { get; set; } = new InteractionRequest<CommonNotification>();
        public InteractionRequest<CommonNotification> ShowWindow2Request { get; set; } = new InteractionRequest<CommonNotification>();
        #endregion



        protected override void InitData()
        {
            base.InitData();
            byte a = 255;
            byte b = 22;
            a += 5;
            System.Diagnostics.Debug.WriteLine(a);

            int d1;
            double d2;
            string s = "223";

            double.TryParse(s, out d2);

            int.TryParse(s, out d1);
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            PreviewKeyDownCommand.Subscribe(o =>
            {

            });

            LoginCommand.Subscribe(o =>
            {
                List<UserBasicInfoMDto> list = new List<UserBasicInfoMDto>();
                /*string connStr = "server=192.168.0.169;username=postgres;password=postgres;database=APPLICATION";
                NpgsqlConnection connection = new NpgsqlConnection(connStr);
                try
                {
                    connection.Open();
                    string commandStr = "select * from g200010.user_basic_info_m";
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(commandStr, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    list = Convert<UserBasicInfoMDto>(dataTable);

                }
                finally
                {
                    connection.Close();
                }*/
                GlobalManager.GetUserBasicInfoMDataManager().SellectAll();
                UserBasicInfoMDto user = GlobalManager.GetUserBasicInfoMDataManager().GetUserBasicInfoMDto(UserName.Value, Password.Value);
                if(user != null)
                {
                    MessageBox.Show("登录成功");
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确");
                    ShowWindow2Request.Raise(new CommonNotification());
                }
            });
        }

        public Action ExeAction = new Action(() =>
        {
            MessageBox.Show("MyCommand");
        });


        private bool MyCanExe(object paramater)
        {
            return true;
        }

        public void NumberChange()
        {
            Subject subject1 = new Subject();
            new BinaryObserver(subject1);
            new OctalObserver(subject1);
            new HexaObserver(subject1);
            System.Diagnostics.Debug.WriteLine("1 state=15");
            subject1.State = 15;
            System.Diagnostics.Debug.WriteLine("1 state=10");
            subject1.State = 10;

            Subject subject2 = new Subject();
            subject2.AddObserver(new BinaryObserver());
            subject2.AddObserver(new OctalObserver());
            subject2.AddObserver(new HexaObserver());
            System.Diagnostics.Debug.WriteLine("2 state=15");
            subject1.State = 15;
            System.Diagnostics.Debug.WriteLine("2 state=10");
            subject1.State = 10;
        }

        public static List<T> Convert<T>(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return null;
            var res = JsonConvert.SerializeObject(dt);
            var mt = JsonConvert.DeserializeObject<List<T>>(res);
            if (mt.Count > 0)
            {
                return mt;
            }
            return null;
        }

    }
}
