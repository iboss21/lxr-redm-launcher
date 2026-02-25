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
using Custom_Dialog.Dialogs.Alert;
using Custom_Dialog.Dialogs.Service;

namespace RedM_Launcher.Tools
{
    internal static class DialogBox
    {
        private static readonly IDialogService _alertServices = new DialogService();

        public static void Information(String message, String title)
        {
            try
            {
                var dialog = new AlertDialogViewModel(title, message, Alerts.Information);
                var result = _alertServices.OpenDialog(dialog);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            //MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
        }

        public static void Warning(String message, String title)
        {
            try
            {
                var dialog = new AlertDialogViewModel(title, message, Alerts.Warning);
                var result = _alertServices.OpenDialog(dialog);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            //MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
        }

        public static void Error(String message, String title)
        {
            try
            {
                var dialog = new AlertDialogViewModel(title, message, Alerts.Error);
                var result = _alertServices.OpenDialog(dialog);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            //MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
        }
    }
}
