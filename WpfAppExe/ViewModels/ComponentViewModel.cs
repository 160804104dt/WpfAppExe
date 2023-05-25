using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;
using WpfAppExe.Views.UserControls;

namespace WpfAppExe.ViewModels
{
    public class ComponentWindowViewModel: ViewModelBase
    {
        public ReactiveProperty<int> SelectedTabIndex { get; set; } = new ReactiveProperty<int>();
        public ListBoxUserControl listBoxUserControl { get; set; } = new ListBoxUserControl();

        protected override void InitData()
        {
            base.InitData();
            Console.WriteLine("画面数据初始化成功");
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            SelectedTabIndex.Subscribe(o =>
            {

            });
        }
    }
}
