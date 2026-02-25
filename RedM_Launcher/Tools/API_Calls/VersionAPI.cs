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
using System.Net;
using System.Reflection;
using System.Xml;

namespace RedM_Launcher.Tools.API_Calls
{
    internal class VersionAPI
    {
        public static bool NeedUpdate
        {
            get
            {
                try
                {
                    if (LastRealesedVersion.Equals("unknown") || CurrentRealesedVersion.Equals(LastRealesedVersion)) return false;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return false;
                }

                return true;
            }
        }

        public static string CurrentRealesedVersion = "unknown";

        public static string LastRealesedVersion = "unkown";


        private static void InitAPI()
        {
            try
            {
                LastRealesedVersion = GetVersionFromGitHub();

                Version version = Assembly.GetExecutingAssembly().GetName().Version!;
                CurrentRealesedVersion = version.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        /// <summary>
        /// Get From Web the current Version On Github
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetVersionFromGitHub(string url = @"https://raw.githubusercontent.com/bastin-thomas/RedM_Launcher/realese/RedM_Launcher/RedM_Launcher.csproj")
        {
            WebClient client = new();
            string data = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            XmlElement RootNode = doc.DocumentElement!;
            XmlNodeList nodes = RootNode.SelectNodes("//Project/PropertyGroup/AssemblyVersion")!;

            foreach (XmlNode node in nodes)
            {
                if (node.Name == "AssemblyVersion")
                {
                    return node.InnerXml!;
                }
            }

            return "unkown";
        }

        internal static void Setup()
        {
            InitAPI();
        }
    }
}
