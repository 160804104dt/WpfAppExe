using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Core
{
    //
    // 摘要:
    //     Represents an interaction request used for confirmations.
    public interface IConfirmation : INotification
    {
        //
        // 摘要:
        //     Gets or sets a value indicating that the confirmation is confirmed.
        bool Confirmed { get; set; }
    }
}
