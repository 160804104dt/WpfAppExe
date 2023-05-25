using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Manager
{
    internal class TestImpl : TestInterface
    {

        public TestImpl()
        {
        }

        public void Run()
        {
            System.Diagnostics.Debug.WriteLine("这是跑方法");
        }
    }
}
