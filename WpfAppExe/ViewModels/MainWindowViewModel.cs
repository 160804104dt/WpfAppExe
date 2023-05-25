using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;
using WpfAppExe.Views;

namespace WpfAppExe.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand ClickCommand { get; set; } = new ReactiveCommand();

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            ClickCommand.Subscribe(o =>
            {
                ComponentWindow componentWindow = new ComponentWindow();
                if(componentWindow.DataContext is ComponentWindowViewModel vm)
                {
                    vm.SelectedTabIndex.Value = Convert.ToInt32((o as string));
                }
                componentWindow.ShowDialog();
            });
        }
    }
}
