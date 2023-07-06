using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;

namespace WpfAppExe.ViewModels
{
    public class TestViewModel:ViewModelBase
    {
        public ReactiveCommand c1 { get; set; } = new ReactiveCommand();

        public ReactiveProperty<string> c2 { get; set; } = new ReactiveProperty<string>();

        public ReactivePropertySlim<string> c3 { get; set; } = new ReactivePropertySlim<string>();

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

        }
    }
}
