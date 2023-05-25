using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Core
{
    //
    // 摘要:
    //     Implementation of the Prism.Interactivity.InteractionRequest.IInteractionRequest
    //     interface.
    public class InteractionRequest<T> : IInteractionRequest where T : INotification
    {
        //
        // 摘要:
        //     Fired when interaction is needed.
        public event EventHandler<InteractionRequestedEventArgs> Raised;

        //
        // 摘要:
        //     Fires the Raised event.
        //
        // 参数:
        //   context:
        //     The context for the interaction request.
        public void Raise(T context)
        {
            Raise(context, delegate
            {
            });
        }

        //
        // 摘要:
        //     Fires the Raised event.
        //
        // 参数:
        //   context:
        //     The context for the interaction request.
        //
        //   callback:
        //     The callback to execute when the interaction is completed.
        public void Raise(T context, Action<T> callback)
        {
            this.Raised?.Invoke(this, new InteractionRequestedEventArgs(context, delegate
            {
                if (callback != null)
                {
                    callback(context);
                }
            }));
        }
    }
}
