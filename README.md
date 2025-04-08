[![Build and Test](https://github.com/Botche/rubik-cube-challenge/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/Botche/rubik-cube-challenge/actions/workflows/dotnet.yml)

# Rubik's Cube Simulator

This is a simple console-based Rubik's Cube simulator built in C#. It allows you to perform face rotations and see the resulting state of the cube. The purpose of this application is not to solve the cube, but to simulate and visualize its rotations from a solved state.

## Features

- Simulate all face rotations (clockwise and counter-clockwise)
- Accept single or multiple commands in sequence
- Reset the cube to a solved state
- Print the cube in a flat view after each command

---

## Commands

| Command | Action                           |
| ------- | -------------------------------- |
| `U`     | Rotate Up face clockwise         |
| `U'`    | Rotate Up face anti-clockwise    |
| `D`     | Rotate Down face clockwise       |
| `D'`    | Rotate Down face anti-clockwise  |
| `R`     | Rotate Right face clockwise      |
| `R'`    | Rotate Right face anti-clockwise |
| `L`     | Rotate Left face clockwise       |
| `L'`    | Rotate Left face anti-clockwise  |
| `F`     | Rotate Front face clockwise      |
| `F'`    | Rotate Front face anti-clockwise |
| `B`     | Rotate Back face clockwise       |
| `B'`    | Rotate Back face anti-clockwise  |
| `RESET` | Reset cube to solved state       |
| `HELP`  | Display valid commands           |
| `EXIT`  | Quit the program                 |

You can enter a **sequence** of commands like:

```
U R F' D L B'
```

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

---

## Build Instructions

1. **Clone the Repository**

2. **Restore Dependencies**

   ```bash
   dotnet restore ./src/RubikCubeChallenge.sln
   ```

3. **Build the Project**

   ```bash
   dotnet build ./src/RubikCubeChallenge.sln
   ```

---

## Run the Console Program

```bash
dotnet run --project ./src/RubikCubeChallenge.Console
```

You’ll be prompted with:

```plaintext
Rubik cube flat view:
<initial cube state>

Enter a rubik cube's operation or sequence of operations:
```

Enter commands such as `U R F'` and press **Enter**.

---

## Run the Web API Program

```bash
dotnet run --project ./src/RubikCubeChallenge.Api
```

A swagger will load with endpoints that are exposing the rubik's cube logic
such as rotating a face, viewing the state of the cube and reseting to the initial state.

---

## Solution Structure

```
RubikCubeChallenge/
├── src/
│   ├── RubikCubeChallenge.Api/                    # API project for future UI or web exposure
│   ├── RubikCubeChallenge.Application/            # Core logic of the Rubik's Cube simulation
│   ├── RubikCubeChallenge.Console/                # Console interface for interacting with the simulator
│   ├── RubikCubeChallenge.UnitTests/              # Unit tests for core cube logic
│   └── RubikCubeChallenge.sln                     # Solution file
```

---

## Notes

- The cube starts in a solved state (Green in front, White on top, Red on right).
- All moves are based on the standard Rubik’s Cube notation.
- The cube is displayed in a flat net (exploded view) in the console.
