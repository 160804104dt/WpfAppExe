
using Microsoft.Xaml.Behaviors;

namespace WpfAppExe.Core
{
    //
    // 摘要:
    //     Custom event trigger for using with Prism.Interactivity.InteractionRequest.IInteractionRequest
    //     objects.
    //
    // 言论：
    //     The standard System.Windows.Interactivity.EventTrigger class can be used instead,
    //     as long as the 'Raised' event name is specified.
    public class InteractionRequestTrigger:EventTrigger
    {
        //
        // 摘要:
        //     Specifies the name of the Event this EventTriggerBase is listening for.
        //
        // 返回结果:
        //     This implementation always returns the Raised event name for ease of connection
        //     with Prism.Interactivity.InteractionRequest.IInteractionRequest.
        protected override string GetEventName()
        {
            return "Raised";
        }
    }
}
