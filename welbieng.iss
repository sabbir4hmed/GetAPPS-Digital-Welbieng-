#define MyAppName "DIGITAL WELLBEING"
#define MyAppVersion "1.1"

#define AppExe "GetAPPS.exe" 
#define SourcePath "C:\Users\SABBIR\source\repos\sabbir4hmed\GetAPPS-Digital-Welbieng-\bin\Debug\net7.0-windows"
#define IconFile "icon.ico" 
#define DotNetInstaller "{#SourcePath}\dotnetruntime.exe"

[Setup]
AppName={#MyAppName}
AppPublisher=SABBIR AHMED
AppCopyright=Copyright © 2024 WALTTON DIGI-TECH INDUSTRIES LTD.
AppReadmeFile=Readme.txt
AppVersion={#MyAppVersion}
DefaultDirName={commonpf64}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename={#MyAppName}_Setup
Compression=lzma
SolidCompression=yes
OutputDir=Output

[Files]
; Copy all files from SourcePath to the application directory
Source: "{#SourcePath}\*"; DestDir: "{app}"


[Run]
; Execute the .NET runtime installer from the source path
Filename: "{#DotNetInstaller}";
Parameters: "/quiet /norestart";
Flags: runhidden postinstall;
Check: DotNetRuntimeIsNotInstalled

; Run the main application after installation
Filename: "{app}\{#AppExe}"; Flags: runhidden postinstall

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; \
    GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Icons]
; Create desktop and start menu icons for the application
Name: "{userdesktop}\{#MyAppName}"; Filename: "{app}\{#AppExe}"; IconFilename: "{app}\{#IconFile}"; Tasks: desktopicon
Name: "{commonstartmenu}\{#MyAppName}"; Filename: "{app}\{#AppExe}"; IconFilename: "{app}\{#IconFile}"; Tasks: desktopicon

[Code]
function DotNetRuntimeIsNotInstalled: Boolean;
begin
  // Check if .NET runtime v7 is not installed
  Result := not RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v7\Full');
end;
