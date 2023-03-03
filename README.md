# ColliderUnifierTool

## Description
A micro script, for Unity, I made to unify the box colliders of the various tiles used in the levels of the game I'm working on for [kibe Software House](https://www.kibesh.com/).
It also places a physics material on the new collider.

The tiles themselves are mostly placed with spawner tool I made to spawn prefab/mesh or 2d textures in a line in a 3d space, without a terrain. 

## How to use
The tool requires that object you want under a single Boxcollider are under a parent, in which you'll add the script, and they need to have a MeshRenderer component.
The tool scans all the children, takes the bounds from the MeshRenderer and disables its Boxcollider.
