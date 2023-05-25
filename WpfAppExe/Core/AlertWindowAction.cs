using Microsoft.Xaml.Behaviors;
using Prism.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using WpfAppExe.Infrastructure;
using WpfAppExe.Interface;
using EventTrigger = System.Windows.EventTrigger;
namespace WpfAppExe.Core
{
    public class AlertWindowAction : TriggerAction<FrameworkElement>
    {
        #region DependencyProperty

        public static readonly DependencyProperty IsWaitViewModelProperty = DependencyProperty.Register(
            "IsWaitViewModel", typeof(bool), typeof(AlertWindowAction), new PropertyMetadata(false));

        public bool IsWaitViewModel
        {
            get => (bool)GetValue(IsWaitViewModelProperty);
            set => SetValue(IsWaitViewModelProperty, value);
        }

        public static readonly DependencyProperty ExtendParameterProperty = DependencyProperty.Register(
            "ExtendParameter", typeof(object), typeof(AlertWindowAction), new PropertyMetadata(null));

        public object ExtendParameter
        {
            get => (object)GetValue(ExtendParameterProperty);
            set => SetValue(ExtendParameterProperty, value);
        }

        public static readonly DependencyProperty IsShowDialogProperty = DependencyProperty.Register(
            "IsShowDialog", typeof(bool), typeof(AlertWindowAction), new PropertyMetadata(false));

        public bool IsShowDialog
        {
            get => (bool)GetValue(IsShowDialogProperty);
            set => SetValue(IsShowDialogProperty, value);
        }

        public static readonly DependencyProperty CloseOwnerProperty = DependencyProperty.Register(
            "CloseOwner", typeof(bool), typeof(AlertWindowAction), new PropertyMetadata(false));

        public bool CloseOwner
        {
            get => (bool)GetValue(CloseOwnerProperty);
            set => SetValue(CloseOwnerProperty, value);
        }

        public static readonly DependencyProperty OwnerProperty = DependencyProperty.Register(
            "Owner", typeof(DependencyObject), typeof(AlertWindowAction), new PropertyMetadata(null));

        public DependencyObject Owner
        {
            get => (DependencyObject)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }


        public static readonly DependencyProperty WindowNameProperty = DependencyProperty.Register(
            "WindowName", typeof(string), typeof(AlertWindowAction), new PropertyMetadata(string.Empty));

        public string WindowName
        {
            get => (string)GetValue(WindowNameProperty);
            set => SetValue(WindowNameProperty, value);
        }

        public static readonly DependencyProperty IsUserControlProperty = DependencyProperty.Register(
            "IsUserControl", typeof(bool), typeof(AlertWindowAction), new PropertyMetadata(false));

        public bool IsUserControl
        {
            get => (bool)GetValue(IsUserControlProperty);
            set => SetValue(IsUserControlProperty, value);
        }
        #endregion

        public AlertWindowAction()
        {

        }

        protected override void Invoke(object parameter)
        {
            var window = GetChildWindow(parameter);

            if (window == null) return;

            //AttachOtherProperties(window, parameter);

            AttachOpenBehavior(window);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected void AttachOpenBehavior(Window window)
        {
            try
            {
                if (IsWaitViewModel) return;
                if (IsShowDialog)
                {
                    window.ShowDialog(); 
                }
                else
                {
                    window.Show();
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
            }
        }

        protected void AttachOtherProperties(Window window, object parameter)
        {
            Action callback = null;
            if (parameter is InteractionRequestedEventArgs arg)
            {
                callback = arg.Callback;
            }

            if (callback != null)
            {
                void Handler(object o, EventArgs e)
                {
                    window.Closed -= Handler;

                    callback();
                }

                window.Closed += Handler;

            }

            if (Owner != null)
            {
                if (Owner is Window ow && ow.IsVisible)
                {
                    window.Owner = ow;
                    Owner = ow;
                }
                else if (Owner is UserControl ctr)
                {

                    var ow1 = Window.GetWindow(ctr);
                    window.Owner = ow1;

                    Owner = ow1;
                }
            }

            if (CloseOwner)
            {
                window.Owner = null;
                (Owner as Window)?.Close();
            }
        }

        protected Window GetChildWindow(object parameter)
        {
            INotification notification = null;

            if (parameter is InteractionRequestedEventArgs arg)
            {
                notification = arg.Context;
            }

            Assembly ass = null;
            ass = GetAssemblyByClassName(WindowName);

            if (ass == null)
            {
                return null;
            }

            Window childWindow = null;
            childWindow = ass.CreateInstance(WindowName) as Window;

            if (childWindow == null) return null;
            //if (notification == null) return childWindow;
            if (childWindow.DataContext == null && notification != null)
            {
                childWindow.DataContext = notification;
            }


            if (childWindow.DataContext is ViewModelBase vb)
            {

                if (ExtendParameter != null) vb.ExtendParameter = ExtendParameter;

                if (IsWaitViewModel)
                {
                    var trigger = new InteractionRequestTrigger();
                    trigger.Attach(childWindow);
                    trigger.SourceObject = vb.WaitViewModelCallRequest;
                }
            }

            Action<IExInteractionRequestAware> action = null;

            action = iira =>
            {
                childWindow.Closing += delegate (object sender, CancelEventArgs args)
                {

                    if (!iira.CanClose())
                    {
                        args.Cancel = true;
                        return;
                    }

                    iira.Dispose();
                };

                if (parameter is InteractionRequestedEventArgs recarg)
                {
                    iira.RoutedInteraction = recarg.Callback;
                }

                iira.Notification = notification;
                iira.FinishInteraction = (Action)(async () =>
                {
                    if (childWindow != null)
                    {
                        //#4635
                        if (!IsShowDialog)
                        {
                            childWindow.Owner = null;
                        }

                        try
                        {
                            childWindow.Close();
                        }
                        catch (ObjectDisposedException e)
                        {
                        }
                    }
                });
            };

            MvvmHelpers.ViewAndViewModelAction(childWindow, action);

            AttachOtherProperties(childWindow, parameter);

            MethodInfo init = childWindow.DataContext?.GetType().GetMethod("AfterConstructorDone");

            // ViewModelのコンストラクタ実行する前にのイベント
            init?.Invoke(childWindow.DataContext, null);

            return childWindow;
        }


        protected Assembly GetAssemblyByClassName(string windowName)
        {
            string[] nameSpaceArr = windowName.Split('.');
            if (nameSpaceArr.Length < 2) return null;
            string assemblyTemp = string.Empty;

            var length = nameSpaceArr.Length - 2;
            for (int i = 0; i <= length; i++)
            {
                assemblyTemp = assemblyTemp + nameSpaceArr[i];
                if (i == length) continue;
                assemblyTemp = assemblyTemp + ".";
            }

            try
            {
                return Assembly.Load(assemblyTemp);
            }
            catch (Exception)
            {
                return GetAssemblyByClassName(assemblyTemp);
            }
        }
    }
}
