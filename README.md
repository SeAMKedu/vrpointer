## Creating a Reliable Pointer for Virtual Reality Applications.

A common user interface style in VR applications is a laser pointer that you use to click buttons. Current VR devices offer highly precise hand tracking, including micro-movements and vibrations. This precision can cause issues such as pointer instability. To address this, we developed an algorithm that filters hand movement, making pointer usage more reliable. Hand movements in 3D space are generally smooth, but the instability in hand orientation across different axes is problematic and we wish to filter that.

An example application is created in Unity. We make a standard VR application in Unity using OpenXR and XR interaction toolkit. We spawn the standard XR Origin (action based). Then we spawn two new game objects under the XR Origin called Line_Left and Line_Right. We make a simple script for those objects that just draw a line forward using a raycast. The controllers have the script that we care about. The script is called LineController.

The script first calculates the angle between the lines orientation and the controllers orientation. It then uses that angle multiplied by an "angleMultiplier" variable to get the smoothing value for the line. Then it changes the lines rotation using Quaternion.Lerp so that it smoothly turns towards the controller. It also updates the lines position, smoothing can also be applied here if needed.

    void Update() {
        float smoothing; 
        
        // Calculate the current angle between the laser pointer and the user's controller
        float theAngle = Quaternion.Angle(Line.rotation, Controller.transform.rotation);
        
        // Calculate the smoothing value.
        smoothing = angleMultiplier * theAngle;

        // Prevent the line from rotating too quickly
        if (smoothing > maxLineRotation) smoothing = maxLineRotation;
        
        // Rotate the line towards the the controller using the Quaternion.Lerp command using the smoothing value.
        Line.rotation = Quaternion.Lerp(Line.rotation, Controller.transform.rotation, smoothing * Time.deltaTime);
        Line.position = Controller.transform.position;
    }



Created by
Sakari Pollari
Expert, R&D
SeAMK
