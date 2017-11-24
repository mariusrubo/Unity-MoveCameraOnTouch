# Unity-MoveCameraOnTouch
A simple script to smoothly move the camera around when displaying objects

# Use
* This script moves the camera within a specified rectangle when a user clicks (or, for Microsoft Surface, touches) the screen.
* The idea is to allow the user to look at and familiarize with 3D objects in a natural and fail-safe way. Camera movements 
roughly simulate head movements when looking at objects placed in front of the user. The camera cannot be moved beyond the 
predefined frame or turned around entirely, since this would expose some users to the risk of being disoriented in the 3D scenario.
* The camera is always smoothly brought to its destination to avoid discontinuities in viewing angle. 

![alt tag](https://github.com/mariusrubo/Unity-MoveCameraOnTouch/blob/master/CameraMove.gif)
