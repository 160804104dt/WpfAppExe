using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModelBase
{
    public abstract class ViewModelBase:BindableBase
    {
        protected virtual void InitData()
        {

        }

        protected virtual void RegisterCommands()
        {

        }

        protected virtual void RegisterProperties()
        {

        }
    }
}
