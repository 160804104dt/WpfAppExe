using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Manager.Interface
{
    public abstract class BaseDataManager<T> : List<T>
    {
        public virtual bool IsLoaded { get; protected set; }
    }
}
