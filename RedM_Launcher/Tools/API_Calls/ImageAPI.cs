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
using System.IO;
using System.Net;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RedM_Launcher.Tools.API_Calls
{
    internal class ImageAPI
    {
        public static ImageSource GetLogo()
        {
            try
            {
                string url = Properties.Settings.Default.OnlineLogo;
                string filePath = @"Online_Launcher_Logo.png";
                WebClient cln = new();
                cln.DownloadFile(url, filePath);
                return GetImageFromSource(filePath);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new BitmapImage(new Uri(Properties.Settings.Default.MainPageLogo, UriKind.Relative));
            }
        }


        public static ImageSource GetBackground()
        {
            try
            {
                string url = Properties.Settings.Default.OnlineBackground;
                string filePath = @"Online_Launcher_Background.png";
                WebClient cln = new();
                cln.DownloadFile(url, filePath);
                return GetImageFromSource(filePath);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new BitmapImage(new Uri(Properties.Settings.Default.MainPageBackground, UriKind.Relative));
            }
        }


        public static BitmapImage GetImageFromSource(string filePath)
        {
            Stream source = new FileStream(App.workingDirectoryPath + filePath, FileMode.Open);

            BitmapImage img = new();
            img.DownloadCompleted += (s, e) =>
            {
                source.Dispose();
            };

            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.StreamSource = source;
            img.EndInit();

            return img;
        }
    }
}
