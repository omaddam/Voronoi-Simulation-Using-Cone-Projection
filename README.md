# Voronoi-Simulation-Using-Cone-Projection
This project simulates the generation of voronoi diagrams. It uses an approach that I have created, similar to the cone projection approach for approximately computing the regions.  

` IMPORTANT: The code is not optimized for handling large number of regions. It is only meant for demonstration purposes.`

The developed solution follows an emergent-behavior approach for computing the regions. It consists of three simple steps.

1) **Initialization**: During this phase, each seed gets an initial region. The region is created by defined number of segments, forming a circular region. The higher the number of segments used, the smoother the circle is, and the more accurate the simulation is.
2) **Expansion**: Once the regions are initialized, all vertices start expanding away from the center of the circle.
3) **Termination**: Once a vertex reaches a collider, it will stop moving. The rest of the vertices will continue expanding until they also reach a blocker.

| Initialization | Expansion | Termination |
| :-----: | :-------: | :-------: |
| <img src="docs/Initialization.gif" height="200" /> | <img src="docs/Expansion.gif" height="200" /> | <img src="docs/Termination.gif" height="200" /> |

# Demo

![Simulation](docs/Simulation.gif)

We created a WebGL application that demonstrates how vornoi regions get created.
A complete demo can be found on [https://omaddam.github.io/Voronoi-Simulation-Using-Cone-Projection/](https://omaddam.github.io/Voronoi-Simulation-Using-Cone-Projection/).

# Getting Started

These instructions will get you a copy of the project on your local machine for development and testing purposes.

### Prerequisites

The things you need to install before you proceed with development:

1) [Unity3d (2020.2.0f1)](https://unity3d.com/get-unity/download/archive) [required].

### Installing

A step by step guide to get you started with development.

#### Download, clone, and setup the repository

```git
git clone https://github.com/omaddam/Voronoi-Simulation-Using-Cone-Projection.git
```

#### Initialize git flow

```git
git flow init
```

# Standards

### General Standards

* Line ending: CRLF
* Case styles: Camel, Pascal, and Snake case
  * Arguments, paramters, and local variables: camel case (e.g. diagramRegion)
  * Global variables: pascal case (e.g. SeedItems)
  * Constants and static variables: snake case (ALL CAPS) (e.g. DIAGRAM_WIDTH)
* Methods naming convention:
  * Pascal case (e.g. GenerateSample)
  * Verbs

### Commenting Standards

* `///` Summaries: Full-usage of English grammar and punctuation. (e.g. Add periods to the end of your summaries, as if you were writing a phrase or sentence.)
*  `//` In-line comments: quick, point-form. Grammar and punctuation not needed

### Assets / App

* Contains all scripts and resources used in the demo.
* Scripts are created under Assets/App/Scripts folder.

### Assets / Others

* All components should be included under Assets/\<Name> folder. (e.g. Assets/VoronoiDiagram)
* Each component should be isolated and under **NO CIRCUMSTANCES** referencing or using another component's scripts.
* Components are **NOT** allowed to reference or call application/demo scripts.

# Code Based Documentation

## Assets / VoronoiDiagram

This folder contains an implementation of voronoi diagram. The diagram consists of two components in addition to the data structure.

### DataStructure

The data structure contains one single class.

* **Seed**: used by the voronoi diagram to create the initial regions.
  * Properties
    * **CircleSegmentCount**: the number of segments used to create the initial region. The higher the number is, the more accurate the visualization is.
    * **PositionX**: the center's x coordinate of the initial region.
    * **PositionY**: the center's y coordinate of the initial region.
    * **Color**: applied to the region initialized by this seed.

### DiagramRegion

A *DiagramRegion* represents a 2D mesh that gets created and managed by its script. It is used as a template by the diagram component when displaying regions.
* Prefab: Assets/VoronoiDiagram/Prefabs/DiagramRegion.prefab
* Script: Assets/VoronoiDiagram/Scripts/DiagramRegion.cs
  * Initialize: creates a 2D circular mesh and sets its color and position based on a seed.
  * Expand: called every frame to expand the boundaries of the region by attempting to move all the verticies away from the center of the region.

### Diagram

A visualization system that uses the *DiagramRegion* rpefab to form the voronoi regions.
* Prefab: Assets/VoronoiDiagram/Prefabs/Diagram.prefab
* Script: Assets/VoronoiDiagram/Scripts/DiagramManager.cs
  * Initialize: initializes the visualization by defining its borders, the speed of the simulation, and initializing the regions.
