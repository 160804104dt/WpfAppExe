using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppExe.Manager;
using Unity;
namespace WpfAppExe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IUnityContainer container = new UnityContainer();
            GlobalManager.Container = container;
            GlobalManager.RegisterContainer();
            this.StartupUri = new Uri("/Views/LoginWindow.xaml", UriKind.Relative);
        }
    }
}
