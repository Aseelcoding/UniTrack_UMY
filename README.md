# UniTrack UMY

UniTrack UMY is a Windows desktop application designed to help UMY students keep track of their courses and academic tasks from MyKlass.

The application uses a WinForms interface and Microsoft Edge WebView2 to sign in to MyKlass. It reads course and activity information from the pages available to the signed-in user and combines it with tasks created manually in UniTrack.

> **Project status:** This project is under active development. Some features and MyKlass page parsing may change as the application evolves.

## Features

- Sign in to MyKlass inside the application.
- Read available courses from the signed-in MyKlass session.
- Parse supported MyKlass activities, including assignments and quizzes.
- View course-related tasks and their due dates/statuses.
- Add and manage manual tasks.
- Filter the Tasks page by course.
- Open MyKlass task links from the task list.
- Store application data locally.

The exact courses and tasks shown depend on the information available to the signed-in MyKlass account and the page structure returned by MyKlass.

## Tech Stack

- C#
- .NET 10 for Windows
- Windows Forms
- Microsoft Edge WebView2
- HtmlAgilityPack
- xUnit (automated tests)

## Requirements

To build and run the project from source:

- Windows 10 or later
- Visual Studio 2022 with the .NET desktop development workload, or the .NET 10 SDK
- Microsoft Edge WebView2 Runtime
- An active UMY MyKlass account

The published application can be distributed as a folder. Keep all files produced by publishing together; do not distribute only the executable.

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/Aseelcoding/UniTrack_UMY.git
   ```

2. Open `UniTrack_UMY.slnx` in Visual Studio.

3. Restore NuGet packages.

4. Build and run `UniTrack_UMY.WinForms`.

5. Sign in to MyKlass through the login window.

## Build from the Command Line

From the repository root:

```bash
dotnet restore UniTrack_UMY.slnx
dotnet build UniTrack_UMY.slnx -c Release
```

To publish a self-contained 64-bit Windows build:

```bash
dotnet publish UniTrack_UMY.WinForms/UniTrack_UMY.WinForms.csproj -c Release -r win-x64 --self-contained true
```

Share the complete publish output folder (or a ZIP of that folder), not just the `.exe` file.

## Project Structure

```text
UniTrack_UMY/
├── UniTrack_UMY.Core/           # Core models and shared application logic
├── UniTrack_UMY.Infrastructure/ # Parsing and infrastructure services
├── UniTrack_UMY.WinForms/       # Windows desktop application
├── UniTrack_UMY.Tests/          # Automated tests
└── UniTrack_UMY.slnx
```

## Notes

- UniTrack does not provide MyKlass accounts. Users sign in with their own credentials.
- Course and activity extraction depends on MyKlass being reachable and on the page content matching the parser's supported structure.
- WebView2 Runtime may need to be installed separately on a target computer.
- Do not share your MyKlass password or session data with anyone.

## License

No license has been specified for this repository yet. Unless a license is added, the repository's contents are not granted an open-source license by default.
