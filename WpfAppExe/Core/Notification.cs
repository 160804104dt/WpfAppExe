using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Core
{
    //
    // 摘要:
    //     Basic implementation of Prism.Interactivity.InteractionRequest.INotification.
    public class Notification : INotification
    {
        //
        // 摘要:
        //     Gets or sets the title to use for the notification.
        public string Title { get; set; }

        //
        // 摘要:
        //     Gets or sets the content of the notification.
        public object Content { get; set; }
    }
}
