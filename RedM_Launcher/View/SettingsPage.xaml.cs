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
using System.Windows;
using System.Windows.Controls;

namespace RedM_Launcher.View
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void passwordWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordWatermark.Visibility = Visibility.Collapsed;
            passwordInput.Visibility = Visibility.Visible;
            passwordInput.Focus();
        }

        private void passwordInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordInput.Text))
            {
                passwordInput.Visibility = Visibility.Collapsed;
                passwordWatermark.Visibility = Visibility.Visible;
            }
        }


        private void ipWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ipWatermark.Visibility = Visibility.Collapsed;
            ipInput.Visibility = Visibility.Visible;
            ipInput.Focus();
        }

        private void ipInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ipInput.Text))
            {
                ipInput.Visibility = Visibility.Collapsed;
                ipWatermark.Visibility = Visibility.Visible;
            }
        }

        private void serveripWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            serveripWatermark.Visibility = Visibility.Collapsed;
            serveripInput.Visibility = Visibility.Visible;
            serveripInput.Focus();
        }

        private void serveripInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(serveripInput.Text))
            {
                serveripInput.Visibility = Visibility.Collapsed;
                serveripWatermark.Visibility = Visibility.Visible;
            }
        }

        private void timerWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            timerWatermark.Visibility = Visibility.Collapsed;
            timerInput.Visibility = Visibility.Visible;
            timerInput.Focus();
        }

        private void timerInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(serveripInput.Text))
            {
                timerInput.Visibility = Visibility.Collapsed;
                timerWatermark.Visibility = Visibility.Visible;
            }
        }
    }
}
