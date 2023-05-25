using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Core
{
    public class InteractionRequestedEventArgs : EventArgs
    {
        //
        // 摘要:
        //     Gets the context for a requested interaction.
        public INotification Context { get; private set; }

        //
        // 摘要:
        //     Gets the callback to execute when an interaction is completed.
        public Action Callback { get; private set; }

        //
        // 摘要:
        //     Constructs a new instance of Prism.Interactivity.InteractionRequest.InteractionRequestedEventArgs
        //
        // 参数:
        //   context:
        //
        //   callback:
        public InteractionRequestedEventArgs(INotification context, Action callback)
        {
            Context = context;
            Callback = callback;
        }
    }
}
