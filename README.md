# Dublin3D
Minimal example of a 3D map of Dublin with data visualisation. Built in Unity

## Setup
Folder contains FBX and CSV to join to it
Place FBX in Assets folder and CSV in Resources
Scale the layer to 1000 and uncheck 'Convert Units' upon import

## Notes
Some IDs will be strings rather than numbers in new layers.

There are still empty nodes with multiple geometries attached in the FBX hierarchy e.g. object 2270. This is a result of clipping the initial shape files to a boundary. 

The values in field 'ZONE_GZT' are going to be changed in the final file as I have descriptions (strings) to replace the current codes.

