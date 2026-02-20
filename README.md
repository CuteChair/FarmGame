# FarmGame

## Overview
farmGame is a top-down 2D gameplay prototype exploring core systems for a potential farming and management game.
Rather than focusing on complete gameplay loops, this project investigates inventory management, persistence, and plant growth systems.

---

## Gameplay Features
- Top-down player movement with directional visuals
- Seed purchasing through an interactable shop and UI
- Seed collection from the world
- Seed planting restricted to fertile ground
- Plants that grow over time with multiple stages and unique visuals

---

## Technical Highlights

### Player & Input
- Directional input tracking to drive player orientation and visuals
- Keyboard and mouse input handling for interaction and placement

### Inventory & UI
- Inventory system built using a dictionary structure
- UI item bar with slot selection
- Shopping interface for seed purchasing

### Persistence & Saving
- Saving and loading system tracking:
  - In-game time progression
  - Planted seed type
  - Growth stage
  - World position
- State persistence maintained between scene transitions

### Plant Growth System
- Time-based growth logic
- Multiple growth stages per plant
- Visual changes driven by growth state

---

## Controls
- WASD – Move  
- E – Interact (shop, shopkeeper)  
- Left Click – Plant seeds  
- 1–9 – Select inventory slots  

---

## Project Status
This project is a gameplay prototype.
Harvesting mechanics, additional plant varieties, expanded shops, and NPC-driven requests are planned but not yet implemented.

---

## How to Run
You can find the playable build on my Itch page : https://themightychair.itch.io/farmgame

---

## Built With
- Unity  
- C#  
