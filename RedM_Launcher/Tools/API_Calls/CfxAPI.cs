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
using System.Text.Json.Nodes;

namespace RedM_Launcher.Tools.API_Calls
{
    internal static class CfxAPI
    {
        public static bool IsOnline
        {
            get
            {
                try
                {
                    return AnalyseJson(GetDataFromWeb());
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// Get The Data From WebPage
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetDataFromWeb(string url = @"https://status.cfx.re/api/v2/status.json")
        {
            WebClient client = new();
            return client.DownloadString(url);
        }
        private static bool AnalyseJson(string json)
        {
            JsonNode rootNode = JsonNode.Parse(json)!;
            JsonNode status = rootNode["status"]!;

            if (status!["indicator"]!.GetValue<string>().Equals("none"))
            {
                return true;
            }

            return false;
        }
    }
}
