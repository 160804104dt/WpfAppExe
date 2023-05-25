using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace WpfAppExe.Manager
{
    public class TestManager
    {
        public static IUnityContainer Container { get; set; } = new UnityContainer();

        static TestManager()
        {
        }

        public static void InitContainer()
        {
            Container.RegisterSingleton<TestInterface, TestImpl>();
        }

        public static TestInterface GetTestInterface()
        {
            return Container.Resolve<TestInterface>();
        }
    }
}
