using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;

namespace WpfAppExe.Interface
{
    //
    // 摘要:
    //     Interface used by the Prism.Interactivity.PopupWindowAction. If the DataContext
    //     object of a view that is shown with this action implements this interface it
    //     will be populated with the Prism.Interactivity.InteractionRequest.INotification
    //     data of the interaction request as well as an System.Action to finish the request
    //     upon invocation.
    public interface IInteractionRequestAware
    {
        //
        // 摘要:
        //     The Prism.Interactivity.InteractionRequest.INotification passed when the interaction
        //     request was raised.
        INotification Notification { get; set; }

        //
        // 摘要:
        //     An System.Action that can be invoked to finish the interaction.
        Action FinishInteraction { get; set; }
    }
}
