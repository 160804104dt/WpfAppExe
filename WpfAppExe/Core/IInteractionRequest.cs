using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Core
{ 
    //
    // 摘要:
    //     Represents a request from user interaction.
    //
    // 言论：
    //     View models can expose interaction request objects through properties and raise
    //     them when user interaction is required so views associated with the view models
    //     can materialize the user interaction using an appropriate mechanism.
    public interface IInteractionRequest
    {
        //
        // 摘要:
        //     Fired when the interaction is needed.
        event EventHandler<InteractionRequestedEventArgs> Raised;
    }
}
