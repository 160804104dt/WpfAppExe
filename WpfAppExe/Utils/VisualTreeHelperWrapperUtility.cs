using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfAppExe.Utils
{
    public class VisualTreeHelperWrapperUtility
    {
        /// <summary>
        /// VisualTreeを親側にたどって指定した型の要素を取得
        /// </summary>
        public T FindAncestor<T>(DependencyObject depObj) where T : DependencyObject
        {
            while (depObj != null)
            {
                if (depObj is T target)
                {
                    return target;
                }
                depObj = VisualTreeHelper.GetParent(depObj);
            }
            return null;
        }

        /// <summary>
        /// VisualTreeを子要素側にたどって指定した型の要素を取得
        /// </summary>
        public T FindDescendant<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) { return null; }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? FindDescendant<T>(child);
                if (result != null) { return result; }
            }
            return null;
        }
    }
}
