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
using Steamworks;
using System.Diagnostics;

namespace RedM_Launcher.Tools.Handlers
{
    public static class Steam
    {
        public static String ProcessName = "Steam";
        public static String ExecName = "steam.exe";

        public static bool HasBeenSkipped = false;

        /// <summary>
        /// All behaviors to Start Steam Properly
        /// </summary>
        public static void Start()
        {
            Logger.Information("Steam Is Running: " + IsRunning);
            Logger.Information("Steam Is Initialized: " + IsInitialized);
            HasBeenSkipped = false;

            // If Steam Is Opened and Ready, skip
            if (IsRunning && IsInitialized)
            {
                Logger.Information("Steam Already Launched Skip Phase");
                HasBeenSkipped = true;
            }
            // If Steam Is Opened and not Ready, Wait it is ready
            else if (IsRunning && !IsInitialized)
            {
                WaitSteamInitialized();
            }
            // If Steam Is Not Open, Launch it
            else
            {
                Logger.Information("Launching Steam");
                _ = Process.Start(Settings.Default.SteamFolder + @"\" + ExecName, "-silent");
                WaitSteamInitialized();
            }

            ShutDownAPI();
        }

        /// <summary>
        /// Wait that Steam is Initialized
        /// </summary>
        private static void WaitSteamInitialized()
        {
            Logger.Information("Waiting Initialisation");
            while (!IsInitialized)
            {
                Thread.Sleep(500);
            }
            Logger.Information("Steam Is Initialized");
        }

        /// <summary>
        /// Shutdown SteamWorksAPI
        /// </summary>
        private static void ShutDownAPI()
        {
            SteamAPI.Shutdown();
            Logger.Information("SteamAPI ShutingDown");
        }

        /// <summary>
        /// Check if Steam Process Running
        /// </summary>
        public static bool IsRunning
        {
            get
            {
                return SteamAPI.IsSteamRunning();
            }
        }

        /// <summary>
        /// Check if Steam is Initialized (ready to Open RedM)
        /// </summary>
        public static bool IsInitialized
        {
            get
            {
                return SteamAPI.Init(); ;
            }
        }
    }
}
