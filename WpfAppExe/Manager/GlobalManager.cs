using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using WpfAppExe.Manager.Entity;
using WpfAppExe.Manager.Interface;

namespace WpfAppExe.Manager
{
    public class GlobalManager
    {
        public static IUnityContainer Container { get; set; }

        public static void RegisterContainer()
        {
            Container.RegisterSingleton<IUserBasicInfoMDataManager, UserBasicInfoMDataManager>();
            Container.RegisterSingleton<IHokenshaNoMDataManager,HokenshaNoMDataManager>();
        }

        public static IUserBasicInfoMDataManager GetUserBasicInfoMDataManager()
        {
            return Container.Resolve<IUserBasicInfoMDataManager>();
        }

        public static IHokenshaNoMDataManager GetHokenshaNoMDataManager()
        {
            return Container.Resolve<IHokenshaNoMDataManager>();
        }

    }
}
