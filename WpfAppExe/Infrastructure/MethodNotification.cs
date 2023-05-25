using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;

namespace WpfAppExe.Infrastructure
{
    public class MethodNotification : Notification
    {
        public object[] Parameters { get; set; }

        public object ReturnParameter { get; set; }

        public MethodNotification()
        {

        }

        public MethodNotification(object[] parameters)
        {
            this.Parameters = parameters;
        }
    }
}
