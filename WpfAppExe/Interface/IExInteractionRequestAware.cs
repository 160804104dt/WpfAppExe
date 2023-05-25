using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Interface
{
    public interface IExInteractionRequestAware : IInteractionRequestAware
    {
        //void Clear();

        void Dispose();

        Action RoutedInteraction { get; set; }

        // 新UI修正ために Started By SLM 2022-6-15 17:11:13		
        bool CanClose();
        // 新UI修正ために Ended By SLM 2022-6-15 17:11:13			
    }
}
