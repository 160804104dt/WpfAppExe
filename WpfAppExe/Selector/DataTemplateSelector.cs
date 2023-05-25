using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfAppExe.Models;

namespace WpfAppExe.Selector
{
    public class ListViewDataTemplateSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var win = container as FrameworkElement;
            if(item is Person person)
            {
               if(person.Age >40)
                    return win.FindResource("Template2") as DataTemplate;
            }
            return win.FindResource("Template1") as DataTemplate;
        }
    }
}
