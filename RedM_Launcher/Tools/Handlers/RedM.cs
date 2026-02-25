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
    internal class RedM
    {
        public readonly static String ProcessName = "RedM";
        public readonly static String ExecName = "RedM.exe";
        public static string Arguments { get { return $"+connect {Settings.Default.RedmServerIP}"; } }
        public static string ProcessFolder { get { return Settings.Default.RedmFolder; } }

        private static ProcessHandler _pr;

        /// <summary>
        /// All behaviors to Start RedM Properly Synchronously
        /// </summary>
        public static void Start(bool asArguments)
        {
            if (asArguments)
            {
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder, Arguments)).Start();
            }
            else
            {
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder)).Start();
            }
        }

        /// <summary>
        /// All behaviors to Start RedM Properly Asynchronously
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
                (_pr = new ProcessHandler(ProcessName, ExecName, ProcessFolder)).StartAsync();
            }
        }

        /// <summary>
        /// Wait that RedM is Initialized
        /// </summary>
        public static void WaitRedMInitialized() => _pr?.WaitProcessInitialized();


        public static async void OnProcessEnd(Action task) => await _pr.ProcessEndCallBack(task);
    }
}
