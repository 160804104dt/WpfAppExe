using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;

namespace WpfAppExe.Infrastructure
{
    public class CommonNotification : IConfirmation
    {
        public string Title { get; set; }
        public object Content { get; set; }
        public bool Confirmed { get; set; }

        public string Comment { get; set; }
        public bool IsEnable { get; set; }
        public object Parameter { get; set; }
        public object ReturnObject { get; set; }

        public CommonNotification()
        {

        }
    }
}
