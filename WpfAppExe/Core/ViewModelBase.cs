using CommonServiceLocator;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WpfAppExe.Enum;
using WpfAppExe.Infrastructure;
using WpfAppExe.Interface;
using WpfAppExe.Utils;
using static WpfAppExe.Enum.EnumConstant;
using static WpfAppExe.Enum.EnumExtension;

namespace WpfAppExe.Core
{
    public abstract class ViewModelBase : BindableBase, IExInteractionRequestAware
    {
        #region フィールド

        private string _windowID;

        public string WindowID
        {
            get => _windowID;
            set
            {

                SetProperty(ref _windowID, value);
                if (!string.IsNullOrEmpty(value))
                {
                    AfterWindowIDChanged();
                }

            }
        }

        private bool _topMost;

        protected List<ContextParameterKey> _contextParameterKeyList { get; set; }

        private INotification _notification;

        //protected EnumConstant.RefreshToken _refreshTokens ;
        /// <summary>
        /// メッセージ保存
        /// </summary>
        [JsonIgnore]
        protected Dictionary<EventBase, HashSet<SubscriptionToken>> _subscribedEvents;

        [JsonIgnore]
        protected bool IsNotificationInitCompleted { get; set; } = true;

        /// <summary>
        /// ViewModelのWindow
        /// </summary>
        protected WeakReference<Window> mainWindow = null;
        #endregion

        #region プロパテ
        /// <summary>
        /// メッセージ交通用
        /// </summary>
        [JsonIgnore]
        public IEventAggregator EventAggregator { get; }
        //public IEventAggregator EventAggregator => PatientInfoParamter?.GetContextEventAggregator();

        public IUnityContainer Container { set; get; } = new UnityContainer();

        public bool IsLoadComplete { get; set; }

        private bool _isModuleActived = true;

        public bool IsModuleActived
        {
            get => _isModuleActived;
            set
            {
                SetProperty(ref _isModuleActived, value);
                if (value) ModuleActived();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Window MainWindow
        {
            get
            {
                if (mainWindow != null)
                {
                    if (mainWindow.TryGetTarget(out Window window))
                    {
                        return window;
                    }
                }

                return null;
            }
            set
            {
                if (mainWindow == null)
                {
                    mainWindow = new WeakReference<Window>(value);
                }
                else
                {
                    mainWindow.SetTarget(value);
                }
            }
        }

        protected virtual void ModuleActived()
        {

        }

        public int RecentPatientSeq { get; set; } = -1;

        public ReactiveProperty<bool> Saved { get; set; } = new ReactiveProperty<bool>(true);

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _isBusyIndeterminate;

        public bool IsBusyIndeterminate
        {
            get { return _isBusyIndeterminate; }
            set { SetProperty(ref _isBusyIndeterminate, value); }
        }

        private string _busyAnimationStyle = "SpinnerBalls";

        public string BusyAnimationStyle
        {
            get { return _busyAnimationStyle; }
            set { SetProperty(ref _busyAnimationStyle, value); }
        }


        protected virtual void ReloadUserSetting(object sender, EventArgs e)
        {

        }

        public virtual void AfterPatientSeqChanged()
        {
            AfterPropertyInjection();
        }

        protected virtual void AfterPropertyInjection()
        {

        }

        protected virtual void LoadData()
        {

        }


        protected void DataModfied()
        {
            Saved.Value = false;
        }

        protected virtual void AfterKarteFrameClosed()
        {

        }

        protected virtual void AfterWindowIDChanged()
        {

        }


        public bool TopMost
        {
            get => _topMost;
            set => SetProperty(ref _topMost, value);
        }

        [JsonIgnore]
        public InteractionRequest<Notification> WaitViewModelCallRequest { get; set; } = new InteractionRequest<Notification>();

        [JsonIgnore]
        public InteractionRequest<Notification> ResetCarteRequest { get; set; } = new InteractionRequest<Notification>();
        [JsonIgnore]
        public InteractionRequest<MethodNotification> WindowLocationSizeRecoveryRequest { get; set; } =
            new InteractionRequest<MethodNotification>();
        [JsonIgnore]
        public InteractionRequest<MethodNotification> GetWindowLocationSizeRequest { get; set; } =
            new InteractionRequest<MethodNotification>();
        [JsonIgnore]
        public CompositeDisposable Disposable { get; }

        [JsonIgnore]
        public INotification Notification
        {
            get => _notification;
            set
            {
                SetProperty(ref _notification, value);
                IsNotificationInitCompleted = false;
                NotificationInit();
                IsNotificationInitCompleted = true;
            }
        }

        private DelegateCommand _workAfterRenderedCommand;

        public DelegateCommand WorkAfterRenderedCommand
        {
            get => _workAfterRenderedCommand;
            set => SetProperty(ref _workAfterRenderedCommand, value);
        }


        private object _extendParameter;
        [JsonIgnore]
        public object ExtendParameter
        {
            get => _extendParameter;
            set => SetProperty(ref _extendParameter, value);
        }

        #endregion


        #region コマンド

        [JsonIgnore]
        public DelegateCommand FinishInteractionCommand { get; set; }

        public ReactiveCommand EscCommand { get; set; }
        public ReactiveCommand F1Command { get; set; }
        public ReactiveCommand F2Command { get; set; }
        public ReactiveCommand F3Command { get; set; }
        public ReactiveCommand F4Command { get; set; }
        public ReactiveCommand F5Command { get; set; }
        public ReactiveCommand F6Command { get; set; }
        public ReactiveCommand F7Command { get; set; }
        public ReactiveCommand F8Command { get; set; }
        public ReactiveCommand F9Command { get; set; }
        public ReactiveCommand F10Command { get; set; }
        public ReactiveCommand F11Command { get; set; }
        public ReactiveCommand F12Command { get; set; }


        #endregion

        #region 初期化

        protected ViewModelBase()
        {
            //Container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            //EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            Disposable = new CompositeDisposable();
            FinishInteractionCommand = new DelegateCommand(() =>
            {
                FinishInteraction?.Invoke();
            });

            EscCommand = new ReactiveCommand().AddTo(Disposable);
            F1Command = new ReactiveCommand().AddTo(Disposable);
            F2Command = new ReactiveCommand().AddTo(Disposable);
            F3Command = new ReactiveCommand().AddTo(Disposable);
            F4Command = new ReactiveCommand().AddTo(Disposable);
            F5Command = new ReactiveCommand().AddTo(Disposable);
            F6Command = new ReactiveCommand().AddTo(Disposable);
            F7Command = new ReactiveCommand().AddTo(Disposable);
            F8Command = new ReactiveCommand().AddTo(Disposable);
            F9Command = new ReactiveCommand().AddTo(Disposable);
            F10Command = new ReactiveCommand().AddTo(Disposable);
            F11Command = new ReactiveCommand().AddTo(Disposable);

            F12Command = new ReactiveCommand().AddTo(Disposable);
            RegisterProperties();
            RegisterCommands();
            //RegisterPubEvents();
            InitData();
        }

        protected virtual void RegisterProperties()
        {
        }

        /// <summary>
        /// コマンドの初期化
        /// </summary>
        protected virtual void RegisterCommands()
        {

        }

        /// <summary>
        /// メッセージイベントの初期化
        /// </summary>
        /*protected virtual void RegisterPubEvents()
        {
            SubscribeEvent<CommonEvents.ClearGamenEvent, string>(p =>
            {
                if (WindowID == p)
                {
                    UnSubscribeAllEvents();
                    ClearProperties();
                    ClearPatientInfoParamter();
                    //Dispose();
                }
            });
        }*/


        /// <summary>
        /// モドルデータの初期化
        /// </summary>
        protected virtual void InitData()
        {
        }
        #endregion

        #region メソッド


        protected bool IsMatchPatientParameter(object condition)
        {
            return true;
        }

        //public void SubscribeEventMatchPatientParameter<T, U>(Action<U> act) where T : PubSubEvent<U>, new()
        //{
        //    SubscribeEvent<T,U>(act,ThreadOption.PublisherThread,false, u =>
        //    {

        //        //if (u is ContextParameter<object> par && par.Context == PatientInfoParamter)
        //        //{

        //        //}
        //    });
        //}

        /// <summary>
        /// イベントをViewModelに保持する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="act"></param>

        //public void SubscribeEvent<T, U>(Action<U> act,ThreadOption threadOption = ThreadOption.PublisherThread,bool keepSubscriberReferenceAlive = false, Predicate<U> filter = null) where T : PubSubEvent<U>, new()
        public void SubscribeEvent<T, U>(Action<U> act) where T : PubSubEvent<U>, new()
        {


            PubSubEvent<U> eve = EventAggregator.GetEvent<T>();

            var token = eve.Subscribe(act).AddTo(Disposable);
            if (_subscribedEvents == null) _subscribedEvents = new Dictionary<EventBase, HashSet<SubscriptionToken>>();
            if (!_subscribedEvents.ContainsKey(eve)) _subscribedEvents.Add(eve, new HashSet<SubscriptionToken>());

            _subscribedEvents[eve].Add(token);
        }

        /// <summary>
        /// イベントをViewModelに保持する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="act"></param>
        public void SubscribeEvent<T>(Action act) where T : PubSubEvent, new()
        {
            PubSubEvent eve = EventAggregator.GetEvent<T>();

            var token = eve.Subscribe(act);

            if (_subscribedEvents == null) _subscribedEvents = new Dictionary<EventBase, HashSet<SubscriptionToken>>();
            if (!_subscribedEvents.ContainsKey(eve)) _subscribedEvents.Add(eve, new HashSet<SubscriptionToken>());

            _subscribedEvents[eve].Add(token);
        }

        /// <summary>
        /// イベントを廃棄する
        /// </summary>
        public void UnSubscribeAllEvents()
        {
            if (_subscribedEvents != null)
            {
                Console.WriteLine($"{GetType()} is UnSubscribeAllEvents");
                foreach (var key in _subscribedEvents.Keys)
                {
                    var tokens = _subscribedEvents[key];

                    foreach (var token in tokens)
                    {
                        key.Unsubscribe(token);
                    }
                }
            }
        }

        public Action FinishInteraction { get; set; }
        public Action RoutedInteraction { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"{GetType()} is Disposed");
            FinishInteractionCommand = null;
            UnSubscribeAllEvents();
            Disposable.Dispose();
        }

        /// <summary>
        /// ViewModel初期化完了すると、特別処理の場合
        /// </summary>
        public virtual void AfterConstructorDone()
        {

        }

        protected virtual void NotificationInit()
        {
        }

        protected virtual void ClearProperties()
        {

        }

        public void ShowBusyIndicator(bool IsIndeterminate = true, string animationStyle = "SpinnerBalls")
        {
            this.IsBusy = true;
            this.BusyAnimationStyle = animationStyle;
            this.IsBusyIndeterminate = IsIndeterminate;
        }

        public void HideBusyIndicator()
        {
            this.IsBusy = false;
        }

        #endregion

        public virtual bool CanClose()
        {
            return true;
        }

        public List<T> GetControlList<T>()
        {
            var window = GetWindow();
            if (window != null)
            {

            }
            return null;
        }

        /// <summary>
        /// 画面を取得する
        /// </summary>
        public virtual Window GetWindow()
        {
            if (MainWindow != null)
            {
                return MainWindow;
            }

            var windows = Application.Current.Windows;
            for (int i = 0; i < windows.Count; i++)
            {
                Window win = windows[i];
                if (win.DataContext is ViewModelBase vm && vm == this)
                {
                    return win;
                }
            }

            return null;
        }

    }
}
