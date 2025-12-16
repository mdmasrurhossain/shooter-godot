# Shooter

A top-down shooter game built with Godot 4.5 and C#. Fight your way through various environments, defeat enemies, and collect items to survive.

## Features

- **Top-down shooter gameplay** - Move, aim, and shoot in a 2D perspective
- **Multiple weapon types** - Use lasers for precision and grenades for area damage
- **Various enemy types** - Face off against Scouts, Drones, Bugs, and Hunters
- **Interactive containers** - Open crates and containers to collect items
- **Multiple levels** - Explore inside buildings, outdoor areas, and houses
- **Resource management** - Manage your health, laser ammo, and grenade supply
- **Item collection system** - Collect items that restore health or provide ammunition

## Controls

- **Movement**: WASD or Arrow Keys
- **Aim**: Mouse cursor (player rotates to face mouse)
- **Primary Action (Shoot Laser)**: Spacebar or Left Mouse Button
- **Secondary Action (Throw Grenade)**: Right Mouse Button

## Game Mechanics

### Player Stats
- **Health**: 60 (can be restored by collecting health items)
- **Laser Ammo**: 20 (starts with 20, uses 1 per shot)
- **Grenade Ammo**: 5 (starts with 5, uses 1 per throw)

### Items
Items spawn from containers when opened:
- **Laser Items** (Blue) - Restores 5 laser ammo
- **Grenade Items** (Red) - Restores 1 grenade
- **Health Items** (Green) - Restores 10 health

### Enemies
- **Scout** - Shoots lasers at the player when nearby
- **Drone** - Flying enemy type
- **Bug** - Ground-based enemy with attack animations
- **Hunter** - Advanced enemy with multiple parts

## Technical Details

- **Engine**: Godot 4.5
- **Language**: C#
- **Rendering**: Mobile-optimized renderer
- **Resolution**: 1280x720
- **Physics Layers**: 
  - Player
  - Enemies
  - Objects
  - Projectiles
  - Items & Zones

## Project Structure

```
shooter/
├── scenes/
│   ├── player/          # Player character
│   ├── enemies/         # Enemy types (Scout, Drone, etc.)
│   ├── levels/          # Level scenes (inside, outside, house)
│   ├── projectiles/     # Laser and grenade projectiles
│   ├── items/           # Collectible items
│   ├── container/       # Containers and interactable objects
│   └── user interface/  # UI elements
├── graphics/            # Sprites and textures
├── audio/               # Sound effects and music
└── globals/             # Global scripts and singletons
```

## Building

This project requires:
- **Godot 4.5** or later
- **.NET SDK** (for C# support)

1. Open the project in Godot Editor
2. The main scene is configured in `project.godot`
3. Build and run from the Godot Editor

## License

[Add your license here]

## Credits

DustyFrogGaming

