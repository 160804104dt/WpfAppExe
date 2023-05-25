using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Core
{
    //
    // 摘要:
    //     Represents an interaction request used for notifications.
    public interface INotification
    {
        //
        // 摘要:
        //     Gets or sets the title to use for the notification.
        string Title { get; set; }

        //
        // 摘要:
        //     Gets or sets the content of the notification.
        object Content { get; set; }
    }
}
