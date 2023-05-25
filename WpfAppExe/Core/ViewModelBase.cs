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

#if R0212_37347 // ======== Patched by WYY at 2020/11/13 13:48:49 for Redmine #37347

        /// <summary>
        /// ロードフラグ
        /// </summary>
        private bool _isLoaded = false;

        /// <summary>
        /// クローズフラグ
        /// </summary>
        private bool _isClosed = false;

        /// <summary>
        /// 画面区分
        /// </summary>
        public string ScreenId = string.Empty;

        /// <summary>
        /// データ更新時 アクセスログ出力
        /// </summary>
        public void UpdateAccessLogWrite(bool updateResult)
        {
            if (!string.IsNullOrEmpty(ScreenId))
            {
                // アクセスログ "データ更新処理を実行しました。" + "[成功]" or "[失敗]"
                System.Threading.Tasks.Task.Run(() => Pharmacy.Common.Utilities.AuditTrailUtility.AccessLogWrite(ScreenId, Pharmacy.Common.Constant.AuditTrail.MessageEnum.DO_UPDATE, updateResult));
            }
        }

        /// <summary>
        /// プライマリーボタン押下時 アクセスログ出力
        /// </summary>
        public void PrimaryButtonAccessLogWrite()
        {
            if (!string.IsNullOrEmpty(ScreenId))
            {
                // アクセスログ "プライマリーボタンを押下しました。"
                System.Threading.Tasks.Task.Run(() => Pharmacy.Common.Utilities.AuditTrailUtility.AccessLogWrite(ScreenId, Pharmacy.Common.Constant.AuditTrail.MessageEnum.DO_PRIMARY));
            }
        }

        /// <summary>
        /// セカンダリーボタン押下時 アクセスログ出力
        /// </summary>
        public void SecondaryButtonAccessLogWrite()
        {
            if (!string.IsNullOrEmpty(ScreenId))
            {
                // アクセスログ "セカンダリーボタンを押下しました。"
                System.Threading.Tasks.Task.Run(() => Pharmacy.Common.Utilities.AuditTrailUtility.AccessLogWrite(ScreenId, Pharmacy.Common.Constant.AuditTrail.MessageEnum.DO_SECONDRY));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void WindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            OnWindowLoaded();

            // 埋め込み型以外
            if (!_isLoaded)
            {
                if (!string.IsNullOrEmpty(ScreenId))
                {
                    // アクセスログ "画面が表示されました。"
                    System.Threading.Tasks.Task.Run(() => Pharmacy.Common.Utilities.AuditTrailUtility.AccessLogWrite(ScreenId, Pharmacy.Common.Constant.AuditTrail.MessageEnum.DO_SHOW));
                }
                _isLoaded = true;
            }
        }

        /// <summary>
        /// ウィンドウ終了前イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">CancelEventArgs</param>
        internal void WindowClosing(object sender, CancelEventArgs e)
        {
            OnWindowClosing(e);
        }

        /// <summary>
        /// ウィンドウ終了イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        internal void WindowClosed(object sender, EventArgs e)
        {
            // 新UI修正ために Started By LJN 2022-9-15 13:02:16
            OnWindowClosed(sender, e);
            // 新UI修正ために Ended By LJN 2022-9-15 13:02:16
            // 埋め込み型以外
            if (!_isClosed)
            {
                if (!string.IsNullOrEmpty(ScreenId))
                {
                    // アクセスログ "画面を閉じました。"
                    System.Threading.Tasks.Task.Run(() => Pharmacy.Common.Utilities.AuditTrailUtility.AccessLogWrite(ScreenId, Pharmacy.Common.Constant.AuditTrail.MessageEnum.DO_CLOSE));
                }
                _isClosed = true;
            }
        }

        /// <summary>
        /// ウィンドウイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        internal void WindowSizeChanged(object sender, EventArgs e)
        {
            OnWindowSizeChanged(e);
        }

        /// <summary>
        /// ウィンドウイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        internal void WindowVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            OnWindowVisibleChanged(e);
        }

        /// <summary>
        /// コンテントレンダードイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        internal void ContentRendered(object sender, EventArgs e)
        {
            OnContentRendered();
        }

        /// <summary>
        /// ウィンドウロードイベント（継承先処理用）
        /// </summary>
        protected virtual void OnWindowLoaded()
        {
        }
        /// <summary>
        /// ウィンドウ終了前イベント（継承先処理用）
        /// </summary>
        /// <param name="e">CancelEventArgs</param>
        protected virtual void OnWindowClosing(CancelEventArgs e)
        {
        }

        /// <summary>
        /// ウィンドウ終了イベント（継承先処理用）
        /// </summary>
        /// <param name="e">CancelEventArgs</param>
        // 新UI修正ために Started By LJN 2022-9-15 13:02:16
        protected virtual void OnWindowClosed(object sender, EventArgs e)
        // 新UI修正ために Ended By LJN 2022-9-15 13:02:16
        {
        }

        /// <summary>
        /// ウィンドウサイズ変更イベント（継承先処理用）
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected virtual void OnWindowSizeChanged(EventArgs e)
        {
        }

        /// <summary>
        /// ウィンドウ表示変更イベント（継承先処理用）
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected virtual void OnWindowVisibleChanged(System.Windows.DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// コンテントレンダードイベント（継承先処理用）
        /// 注）UserControl では GotFocus によるトリガ
        /// </summary>
        protected virtual void OnContentRendered()
        {
        }
        /// <summary>
        /// OutputMessage
        /// </summary>
        /// <param name="key">定義メッセージの Key 値（例："PMCI_000001"）</param>
        /// <param name="parameters">追加文字列</param>
        /// <returns>ダイアログの処理結果</returns>
        protected EnumMessageBoxResult OutputMessage(string key, params string[] parameters)
        {
            return OutputMessage(key, IntPtr.Zero, parameters);
        }
        protected EnumMessageBoxResult OutputMessage(string key, IntPtr hWnd, params string[] parameters)
        {

            // メッセージ取得
            var msgVal = MessageManager.Messages[key];

            if (msgVal == null)
            {
                // メッセージ未定義（ClientErrXXXX で代用）
                msgVal = MessageManager.Messages["ClientErrXXXX"];
                return EnumMessageBoxResult.OK;
            }

            string messageBody = string.Format(msgVal.Text, parameters);

            return EmpMessage.Show(msgVal.Icon, msgVal.Title, messageBody, msgVal.ButtonType, null, msgVal.DefaultKey, hWnd);
        }

#endif

        // 新UI修正ために Started By SLM 2022-6-15 17:11:13		
        /// <summary>×ボタンを押した時に閉じれるかどうか</summary>
        /// <returns>
        ///   <c>true</c> if this instance can close; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool CanClose()
        {
            return true;
        }
        // 新UI修正ために Ended By SLM 2022-6-15 17:11:13		
    }
}
