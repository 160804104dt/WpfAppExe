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
            byte c = (byte)(a + b);
            int d = a + b;
            int e = a + 2;
            int f = (byte)(a + 2);
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
                //System.Diagnostics.Debug.WriteLine(o);
                if(o is MouseButtonEventArgs)
                {

                }
            });

            LoginCommand.Subscribe(o =>
            {
                /*List<UserBasicInfoMDto> list = new List<UserBasicInfoMDto>();
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
                }*/
                Window1 window1 = new Window1();
                window1.ShowDialog();
            });
        }
    }
}
