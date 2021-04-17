# Command line util to grab .NET local info

## Command Help

```
~ dotnet-local-info -h
1.0.0.0

Usage: dotnet-local-info [command] [options]

Options:
  --version        Show version information.
  -?|-h|--help     Show help information.

Commands:
  special-folders  Show .NET Special Folders Path

Run 'dotnet-local-info [command] -?|-h|--help' for more information about a command.

Command line utils to retrieve .NET local info
```

## special-folders

Retrieve the value of special forlders path:

```
~ dotnet-local-info special-folders -h
Show .NET Special Folders Path

Usage: dotnet-local-info special-folders [options]

Options:
  -f|--filter <REGEX>  Filter special folder names
  --all                Show all special folders including those without a value
  -?|-h|--help         Show help information.
Enumerates the actual values of the Environment.SpecialFolder Enum
```

### Example

```
~ dotnet-local-info special-folders
Desktop: /Users/gc/Desktop
MyDocuments: /Users/gc
MyDocuments: /Users/gc
Favorites: /Users/gc/Library/Favorites
MyMusic: /Users/gc/Music
DesktopDirectory: /Users/gc/Desktop
Fonts: /Users/gc/Library/Fonts
ApplicationData: /Users/gc/.config
LocalApplicationData: /Users/gc/.local/share
InternetCache: /Users/gc/Library/Caches
CommonApplicationData: /usr/share
System: /System
ProgramFiles: /Applications
MyPictures: /Users/gc/Pictures
UserProfile: /Users/gc
```