# Student Survivors

## Overview
Student Survivors is a C# desktop game where players select a character and navigate through various challenges. The game features multiple playable characters, animated sprites, and a dynamic environment.

## Features
- Multiple playable characters (Ascendant, Elijah, Eternal, Rianne, etc.)
- Animated movement and sprite assets
- Shooting mechanics (see `Bullet.cs`)
- Character selection screen
- Score and leaderboard system (see `Leaderboard.txt`)
- Custom backgrounds and environments

## Getting Started

### Prerequisites
- Windows OS
- .NET Framework (compatible with the version used in `Game.csproj`)

### How to Build and Run
1. Open the solution file `Game.sln` in Visual Studio.
2. Build the solution (Ctrl+Shift+B).
3. Run the game (F5 or click the Start button).
4. Alternatively, run the compiled `Game.exe` in the `bin/Debug/` or `bin/Release/` folder.

## Controls
- Arrow keys: Move character
- Spacebar: Shoot
- Mouse: Select character (on selection screen)

## Project Structure
```
|-- App.config
|-- Bullet.cs
|-- charSelected.cs
|-- Gamescreen.cs
|-- Main_Game.cs
|-- Program.cs
|-- bin/
|   |-- Debug/
|   |-- Release/
|-- obj/
|-- Properties/
|-- Essentials/ (backgrounds, ammo images)
|-- Sprite <Character>/ (character sprite assets)
```

## Assets
All images and sprites are located in the `bin/Debug/Essentials/` and `bin/Debug/Sprite <Character>/` folders. Each character has a dedicated folder for their movement and animation sprites.

## Credits
- Developed by Chaaan and the Group
- Sprite and background assets created by the development team or sourced as noted in asset folders.

## License
This project is for educational and personal use. Please credit the original authors if reusing assets or code.
