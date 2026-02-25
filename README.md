```
    ██╗     ██╗  ██╗██████╗        ██████╗ ██████╗ ██████╗ ███████╗
    ██║     ╚██╗██╔╝██╔══██╗      ██╔════╝██╔═══██╗██╔══██╗██╔════╝
    ██║      ╚███╔╝ ██████╔╝█████╗██║     ██║   ██║██████╔╝█████╗
    ██║      ██╔██╗ ██╔══██╗╚════╝██║     ██║   ██║██╔══██╗██╔══╝
    ███████╗██╔╝ ██╗██║  ██║      ╚██████╗╚██████╔╝██║  ██║███████╗
    ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝

    ██████╗ ███████╗██████╗ ███╗   ███╗    ██╗      █████╗ ██╗   ██╗███╗   ██╗ ██████╗██╗  ██╗███████╗██████╗
    ██╔══██╗██╔════╝██╔══██╗████╗ ████║    ██║     ██╔══██╗██║   ██║████╗  ██║██╔════╝██║  ██║██╔════╝██╔══██╗
    ██████╔╝█████╗  ██║  ██║██╔████╔██║    ██║     ███████║██║   ██║██╔██╗ ██║██║     ███████║█████╗  ██████╔╝
    ██╔══██╗██╔══╝  ██║  ██║██║╚██╔╝██║    ██║     ██╔══██║██║   ██║██║╚██╗██║██║     ██╔══██║██╔══╝  ██╔══██╗
    ██║  ██║███████╗██████╔╝██║ ╚═╝ ██║    ███████╗██║  ██║╚██████╔╝██║ ╚████║╚██████╗██║  ██║███████╗██║  ██║
    ╚═╝  ╚═╝╚══════╝╚═════╝ ╚═╝     ╚═╝    ╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝
```

# 🐺 LXR RedM Launcher

> **The Land of Wolves** — Georgian RP 🇬🇪 | მგლების მიწა - რჩეულთა ადგილი!
> *ისტორია ცოცხლდება აქ!* (History Lives Here!)

═══════════════════════════════════════════════════════════════════════════════

## 📋 Server Information

| Key          | Value                                      |
|--------------|--------------------------------------------|
| **Server**   | The Land of Wolves 🐺                      |
| **Type**     | Serious Hardcore Roleplay                  |
| **Access**   | Discord & Whitelisted                      |
| **Developer**| iBoss21 / The Lux Empire                   |
| **Website**  | https://www.wolves.land                    |
| **Discord**  | https://discord.gg/CrKcWdfd3A              |
| **GitHub**   | https://github.com/iBoss21                 |
| **Store**    | https://theluxempire.tebex.io              |
| **Server**   | https://servers.redm.net/servers/detail/8gj7eb |

═══════════════════════════════════════════════════════════════════════════════

## 🔧 Framework Support

| Framework        | Status               |
|------------------|----------------------|
| **LXR Core**     | ✅ Primary            |
| **RSG Core**     | ✅ Primary            |
| **VORP Core**    | ⚙️ Supported / Legacy |

═══════════════════════════════════════════════════════════════════════════════

## 📖 About

The LXR RedM Launcher is a custom Windows desktop client launcher built for **The Land of Wolves** RedM server. It automates all pre-launch tasks before connecting to RedM — clearing temporary files, launching Steam, Rockstar Launcher, Epic Games Store, and TeamSpeak — then launches your RedM client with direct server connect.

### Key Features

- 🚀 **One-Click Launch** — Start all prerequisites and connect to RedM in one click
- 🔄 **Auto Cache Clear** — Automatically clear RedM cache on launch
- 🎮 **Smart Process Management** — Detects and launches Steam, Rockstar, Epic Games, TeamSpeak
- 🌐 **Server Status** — Real-time server online/offline status and player count
- 🎨 **Dynamic Theming** — Online-configurable logos and backgrounds
- 🔒 **Single Instance** — Mutex-based single instance enforcement
- 🌍 **Internationalization** — English & French support (auto-detected from OS)
- ⚙️ **Settings Page** — Configure all paths, IPs, and launch options
- 👁️ **Auto-Hide** — Hides launcher while RedM is running

═══════════════════════════════════════════════════════════════════════════════

## 🖥️ For Developers

### Prerequisites

- [Visual Studio 2022+ with .NET desktop development module (.NET 8.0)](https://visualstudio.microsoft.com/fr/free-developer-offers/)
- Windows 10 (Build 18362) or later
- x64 platform

### How To Build

1. Clone this repository
2. Open `RedM_Launcher.sln` in Visual Studio
3. Restore NuGet packages
4. Press **F5** or click the *Play Button* to build and run

### Project Structure

```
lxr-redm-launcher/
├── Custom_Dialog/              # Custom WPF dialog library
│   ├── Dialogs/
│   │   ├── Alert/              # Alert dialog view/viewmodel
│   │   ├── Service/            # Dialog service infrastructure
│   │   └── Themes/             # Dialog theming
│   └── .Resources/             # Dialog icons & fonts
├── RedM_Launcher/              # Main launcher application
│   ├── Converters/             # WPF value converters
│   ├── Model/Utils/            # CallbackTimer, RelayCommand
│   ├── Tools/
│   │   ├── API_Calls/          # CfxAPI, VersionAPI, ImageAPI, ServerAPI
│   │   └── Handlers/           # RedM, Steam, Rockstar, Epic, TeamSpeak, Cache
│   ├── View/                   # XAML UI (MainWindow, MainPage, SettingsPage)
│   ├── ViewModel/              # MVVM ViewModels
│   └── Properties/             # Localization (EN/FR), Settings
├── ExternalLibs/               # Steamworks.NET references
├── .RedM_Resources/            # RedM executables & batch files
└── .Documentation/             # Design mockups & inspiration
```

═══════════════════════════════════════════════════════════════════════════════

## 🎨 Design

![MainPage](./.Documentation/Mockup/MainPage.png)
![SettingPage](./.Documentation/Mockup/SettingPage.png)

═══════════════════════════════════════════════════════════════════════════════

## 📝 Changelog

### 🐛 Next Fix Update

- ☐ Better Popup Thread handling (popup currently not showing because not in UI Thread)

### 🐛 1.0.1 Hotfix

- ✅ Fix concurrency access to online Background/logo
- ✅ Add Mutex to have only one App instance at same time

### ♻️ 1.1 Roadmap

- ☐ Launching Pop Bar (Skippable Timer + What's going on)
- ☐ Create functions to get RP Board Data and displaying them on the mainpage

### ♻️ 1.0 Release

- ✅ ReadMe Creation
- ✅ Repository Folder Tree Creation
- ✅ Main Window View / ViewModel Creation
- ✅ Main Page View / ViewModel Creation
- ✅ Setting Page View / ViewModel Creation
  - RedM Folder + install azerty at Launch + Clear Cache at Launch
  - RedM IP String + Auto-Connect or not
  - Steam Folder / Epic Folder / Rockstar Folder / TeamSpeak Folder
- ✅ App Model Creation (Storable) → .NET Settings
- ✅ Navigation Logic / Routing Creation
- ✅ Launch RedM with auto-connect to an IP or not
- ✅ Clear the Cache
- ✅ Launch all needed Launchers
- ✅ Launch TeamSpeak on the right Server
- ✅ First Launch Management
- ✅ Dynamic Enable/Disable MainButton + Text / Background
- ✅ Hide App on RedM Launch, Show App on RedM Close
- ✅ CFX RedM Status + Server Status (UI)
- ✅ Internationalization (EN & FR, OS auto-detect)
- ✅ Custom Popups
- ✅ Online Backgrounds / Logos
- ✅ "Hide When RedM Running" Setting

═══════════════════════════════════════════════════════════════════════════════

## 🎨 Inspiration

The launcher takes its inspiration from a project created by Zerator's Community, and the Rockstar Launcher UI.

![SOZ Launcher](./.Documentation/Inspiration/SOZ_Launcher.jpg)
![Rockstar MainPage](./.Documentation/Inspiration/Rockstar1.png)
![Rockstar SettingPage](./.Documentation/Inspiration/Rockstar2.png)

═══════════════════════════════════════════════════════════════════════════════

## 📜 Credits

| Role              | Credit                          |
|-------------------|---------------------------------|
| **Script Author** | iBoss21 / The Lux Empire        |
| **Brand**         | 🐺 wolves.land — The Land of Wolves |
| **Original Base** | Arkios / Community Contribution |

═══════════════════════════════════════════════════════════════════════════════

> **© 2026 iBoss21 / The Lux Empire | wolves.land | All Rights Reserved**
>
> Tags: `RedM` `Georgian` `SeriousRP` `Whitelist` `Launcher` `WPF` `.NET8` `LXR-Core` `RSG-Core` `VORP-Core`
