using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfAppExe.Utils
{
    public class ControlUtil
    {

        public static void GetControlList<T>(DependencyObject control,IList<T> lst) where T : DependencyObject
        {
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(control) - 1; i++)
            {
                var child = VisualTreeHelper.GetChild(control,i);
                if (child.GetType() == typeof(T))
                {
                    lst.Add(child as T);
                }
                else if (VisualTreeHelper.GetChildrenCount(child) > 0)
                {
                    if (child is DependencyObject)
                    {
                        GetControlList(child,lst);
                    }
                }
            }
        }

    }
}
