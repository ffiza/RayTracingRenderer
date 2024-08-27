<div align="center">
    <h1>Ray Tracing Renderer</h1>
</div>

<p align="center">
    <img src="https://forthebadge.com/images/badges/made-with-c-sharp.svg"></a>
</p>

A very simple 3D renderer that uses ray tracing. All code is written in C#.

This program calculates the color values of each pixel on a 2D canvas projected onto a 2D viewport that exists in 3D space. The color is computed by intersecting rays with spheres (the only model implemented so far). The program determines the canvas color based on the position (for shadows) and color of each sphere, the lights included in the scene (point, directional, and ambient lights are implemented), as well as the specularity and reflection index of each object.

This project is inspired by the book *Computer Graphics from Scratch* by Gabriel Gambetta.

<p align="center">
    <img src="https://i.imgur.com/SIJRrYn.png" width=400>
</p>
<p align="center">An example of a 3D scene rendered at the current state of the project.</p>

Future Work:

* Implement ray tracing with triangles using the Möller-Trumbore algorithm.
* Implement cubes and other primitives composed of triangles.
* Add parallelization for ray calculations.
* Implement objects with transparency.