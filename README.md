# SpacePotato

SpacePotato is a Unity rocket navigation game where the player pilots a small spacecraft through obstacle-filled levels, lands on finish pads, and advances through a short scene sequence.

## Project Details

- Engine: Unity 6000.5.0f1
- Render pipeline: Universal Render Pipeline
- Input: Unity Input System
- Main build scenes:
  - `Assets/Scenes/over.unity`
  - `Assets/Scenes/under.unity`
  - `Assets/Scenes/through.unity`

## Gameplay

The player controls a rocket with thrust and rotation. Colliding with a finish pad advances to the next level, while colliding with other objects plays a crash effect and reloads the current level.

Core gameplay scripts:

- `Assets/Scripts/movement.cs` handles thrust, rotation, engine audio, and thruster particles.
- `Assets/Scripts/collision.cs` handles friendly collisions, crashes, finish triggers, level reloads, and level progression.

## Controls

The project uses serialized `InputAction` fields assigned in Unity:

- Thrust: applies upward force and plays the main engine effect.
- Rotate: rotates the rocket left or right.
- `L`: debug shortcut to load the next level.

## Assets

The project includes:

- Rocket, vehicle, building, rock, and space-themed prefabs in `Assets/Prefabs`
- Particle effects in `Assets/Particles`
- Audio clips for thrust, crashes, and success feedback in `Assets/audio`
- URP renderer and volume settings in `Assets/Settings`

## Getting Started

1. Clone the repository.
2. Open the project folder in Unity 6000.5.0f1 or newer compatible Unity 6 editor.
3. Let Unity restore packages from `Packages/manifest.json`.
4. Open `Assets/Scenes/over.unity`.
5. Press Play to test the first level.

## Build Notes

The active build order is configured in `ProjectSettings/EditorBuildSettings.asset`:

1. `over`
2. `under`
3. `through`

When the final scene is completed, the game loops back to the first scene.
