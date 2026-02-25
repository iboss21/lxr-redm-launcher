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
using System.Diagnostics;
using System.IO;

namespace RedM_Launcher.Tools
{
    public static class Logger
    {
        private static TextWriterTraceListener fileListener;
        public static void Setup()
        {
            if (!Directory.Exists(App.workingDirectoryPath + $"/Logs/"))
            {
                Directory.CreateDirectory(App.workingDirectoryPath + $"/Logs/");
            }

            fileListener = new(App.workingDirectoryPath + $"/Logs/MainLog-{DateTime.Now:yyyy_MM_dd-HH_mm_ss}.txt");

            Trace.Listeners.Add(fileListener);
            Trace.WriteLine(@"
═══════════════════════════════════════════════════════════════════════════════

    ██╗     ██╗  ██╗██████╗        ██████╗ ██████╗ ██████╗ ███████╗
    ██║     ╚██╗██╔╝██╔══██╗      ██╔════╝██╔═══██╗██╔══██╗██╔════╝
    ██║      ╚███╔╝ ██████╔╝█████╗██║     ██║   ██║██████╔╝█████╗
    ██║      ██╔██╗ ██╔══██╗╚════╝██║     ██║   ██║██╔══██╗██╔══╝
    ███████╗██╔╝ ██╗██║  ██║      ╚██████╗╚██████╔╝██║  ██║███████╗
    ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝

═══════════════════════════════════════════════════════════════════════════════
    🐺 LXR REDM LAUNCHER — SUCCESSFULLY LOADED
═══════════════════════════════════════════════════════════════════════════════

    Server:      The Land of Wolves 🐺
    Developer:   iBoss21 / The Lux Empire
    Website:     https://www.wolves.land
    Discord:     https://discord.gg/CrKcWdfd3A

═══════════════════════════════════════════════════════════════════════════════
");
        }

        public static void Information(string message)
        {
            Trace.TraceInformation($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}");
            Trace.Flush();
        }

        public static void Warning(string message)
        {
            Trace.TraceWarning($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [WARN] {message}");
            Trace.Flush();
        }

        public static void Error(string? message)
        {
            if (message == null)
            {
                return;
            }

            Trace.TraceWarning($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}");
            Trace.Flush();
        }

        public static void LogError(Exception exception)
        {
            Trace.TraceError($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {exception.Message}\n{exception}");
            Trace.Flush();
        }
    }
}
