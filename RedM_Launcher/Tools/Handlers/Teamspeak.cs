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
using System.Net;

namespace RedM_Launcher.Tools.Handlers
{
    internal class Teamspeak
    {
        public readonly static string ProcessName = "ts3client_win64";
        public readonly static string ExecName = "ts3client_win64.exe";
        public static string Arguments { get { return $"ts3server://{Settings.Default.TSServerIP}?password={Settings.Default.TSPassword}"; } }
        public static string ProcessFolder { get { return Settings.Default.TeamSpeakFolder; } }

        private static ProcessHandler _pr;

        /// <summary>
        /// All behaviors to Start Teamspeak Properly Synchronously
        /// </summary>
        public static void Start(bool asArguments)
        {
            IPAddress? addr;
            bool ValidateIP = IPAddress.TryParse(Settings.Default.TSServerIP, out addr);

            if (asArguments && ValidateIP)
            {
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder, Arguments)).Start();
            }
            else
            {
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder, "")).Start();
            }
        }

        /// <summary>
        /// All behaviors to Start Teamspeak Properly Asynchronously
        /// </summary>
        /// 
        public static void StartAsync(bool asArguments)
        {
            if (asArguments)
            {
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder, Arguments)).StartAsync();
            }
            else
            {
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder, "")).StartAsync();
            }
        }

        /// <summary>
        /// Wait that Teamspeak is Initialized
        /// </summary>
        public static void WaitTeamspeakInitialized() => _pr?.WaitProcessInitialized();
    }
}
