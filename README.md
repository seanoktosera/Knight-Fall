# Knight Fall

A 3D action prototype developed in Unity as a campus game development project at Universitas Multimedia Nusantara (UMN).

## 🎮 Gameplay

[![Gameplay Trailer](https://img.shields.io/badge/YouTube-Gameplay%20Trailer-red?logo=youtube)](https://youtu.be/bv6INPF9cFo?si=COy5l1OByZGVt-F8)
[![Play on itch.io](https://img.shields.io/badge/itch.io-Play%20Now-FA5C5C?logo=itch.io)](https://knightfall-umn.itch.io/knight-fall)

## ✨ Features

- **Combat System** — Combo-based melee attacks using Unity Animator State Machine with seamless attack transitions and animation blending
- **FSM-based AI** — Enemy behavior powered by Finite State Machine managing idle, patrol, chase, and attack states
- **Player Controller** — Responsive input handling with movement, jumping, and combat integration
- **Health System** — Player and enemy health management with UI feedback
- **Game Flow** — Main menu, win/lose conditions, and game over screen

## 🛠️ Built With

- **Engine** — Unity
- **Language** — C#
- **Systems** — Finite State Machine, Unity Animator, NavMesh AI

## 📁 Project Structure

```
Assets/
├── Knight.cs           # Player controller & combat logic
├── KnightHitbox.cs     # Hitbox detection for player attacks
├── Skeleton.cs         # Enemy FSM behavior
├── EnemyHealth.cs      # Enemy health & damage system
├── PlayerHealthUI.cs   # Health bar UI
├── WinManager.cs       # Win condition logic
├── GameOverManager.cs  # Game over handling
├── MainMenu.cs         # Main menu controller
└── Camera.cs           # Camera follow system
```

## 👤 Developer

**Sean Rizkiardy Oktosera**
Informatics Student — Universitas Multimedia Nusantara

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Sean%20Rizkiardy-blue?logo=linkedin)](https://linkedin.com/in/sean-rizkiardy)
