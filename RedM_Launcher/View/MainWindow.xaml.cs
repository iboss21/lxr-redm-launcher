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
using System.Windows;
using System.Windows.Input;

namespace RedM_Launcher.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Settings Config = Properties.Settings.Default;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Config.Save();
            Logger.Information("App is Closed Normally");
            
            InstanceChecker.MutexRealese();
            Logger.Information("Free the Mutex");
                        
            Close();
        }

        private void onLoaded(object sender, RoutedEventArgs e)
        {
            if (VersionAPI.NeedUpdate)
            {
                string Title = (string)App.Current.FindResource("NeedUpdate_Popup_Warning_Title");
                string Message = (string)App.Current.FindResource("NeedUpdate_Popup_Warning_Message");
                DialogBox.Warning(Message, Title);
            }
        }
    }
}
