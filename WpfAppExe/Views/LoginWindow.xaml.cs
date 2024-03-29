﻿using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppExe.Core;
using WpfAppExe.Models;
using WpfAppExe.ViewModels;

namespace WpfAppExe.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : MyWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            Console.WriteLine(e);
        }

        private void Password_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
