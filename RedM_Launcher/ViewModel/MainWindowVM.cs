// ═══════════════════════════════════════════════════════════════════════════════
//
//     ██╗     ██╗  ██╗██████╗        ██████╗ ██████╗ ██████╗ ███████╗
//     ██║     ╚██╗██╔╝██╔══██╗      ██╔════╝██╔═══██╗██╔══██╗██╔════╝
//     ██║      ╚███╔╝ ██████╔╝█████╗██║     ██║   ██║██████╔╝█████╗
//     ██║      ██╔██╗ ██╔══██╗╚════╝██║     ██║   ██║██╔══██╗██╔══╝
//     ███████╗██╔╝ ██╗██║  ██║      ╚██████╗╚██████╔╝██║  ██║███████╗
//     ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝
//
//     🐺 LXR-Core — RedM Launcher
//     The Land of Wolves | wolves.land
//
// ═══════════════════════════════════════════════════════════════════════════════
//
//     Server:      The Land of Wolves 🐺
//     Tagline:     Georgian RP 🇬🇪 | მგლების მიწა - რჩეულთა ადგილი!
//     Type:        Serious Hardcore Roleplay
//     Access:      Discord & Whitelisted
//
//     Developer:   iBoss21 / The Lux Empire
//     Website:     https://www.wolves.land
//     Discord:     https://discord.gg/CrKcWdfd3A
//     GitHub:      https://github.com/iBoss21
//     Store:       https://theluxempire.tebex.io
//
//     Framework Support:
//     - LXR Core (Primary)
//     - RSG Core (Primary)
//     - VORP Core (Supported / Legacy)
//
//     © 2026 iBoss21 / The Lux Empire | wolves.land | All Rights Reserved
//
// ═══════════════════════════════════════════════════════════════════════════════
using RedM_Launcher.Properties;
using RedM_Launcher.Tools;
using RedM_Launcher.Tools.API_Calls;
using RedM_Launcher.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace RedM_Launcher.ViewModel
{
    /// <summary>
    /// The Main Window
    /// </summary>
    class MainWindowVM : INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// The current Page (User Control)
        /// </summary>
        private object? _currentPage;

        /// <summary>
        /// Is In SettingPage or in MainPage
        /// </summary>
        private int _stateMachine;

        /// <summary>
        /// The currently loaded Background
        /// </summary>
        private ImageSource _background;
        #endregion

        #region Accessors
        public object? CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(); }
        }

        public int StateMachine
        {
            get { return _stateMachine; }
            set { _stateMachine = value; OnPropertyChanged(); }
        }

        public static Settings Config
        {
            get { return Properties.Settings.Default; }
        }
        public ImageSource Background
        {
            get { return _background; }
            set { _background = value; }
        }



        public MainPageVM MainPage { get; set; }
        public SettingsPageVM Settings { get; set; }
        #endregion

        #region Constructors
        public MainWindowVM()
        {
            Background = ImageAPI.GetBackground();

            MainPage = new MainPageVM();
            Settings = new SettingsPageVM();

            CurrentPage = MainPage;
            StateMachine = 0;
        }
        #endregion

        #region Methods
        #endregion

        #region Events
        #region Commands
        public RelayCommand OnSettingClick => new(execute =>
        {
            switch (StateMachine)
            {
                case 0:
                    CurrentPage = Settings;
                    StateMachine = 1;
                    Logger.Information("== Go To Settings Page ==");
                    break;
                case 1:
                default:
                    CurrentPage = MainPage;
                    StateMachine = 0;
                    Logger.Information("== Go To Main Page ==");
                    Config.Save();
                    break;
            }
        });

        public RelayCommand OnMinimizedClick => new(execute =>
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        });
        #endregion

        #region INotifiedProperty Block
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
