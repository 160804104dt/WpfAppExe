using MyComponent1.Component;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppExe.Utils;

namespace WpfAppExe.Core
{
    public class MyWindow:Window
    {

        protected ArrayList functionKeyList = null;

        public MyWindow()
        {
            PreviewKeyDown -= new KeyEventHandler(DefaultPreviewKeyDown);
            PreviewKeyDown += new KeyEventHandler(DefaultPreviewKeyDown);
        }

        private void DefaultPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(functionKeyList == null)
            {
                functionKeyList = GetFunctionKeyButtons();
            }

            var list = functionKeyList;
        }

        public virtual ArrayList GetFunctionKeyButtons()
        {
            var btnLst = new ArrayList();
            //WindowHelper.GetControlList(this, btnLst, typeof(MyButton));
            return btnLst;
        }

    }
}
