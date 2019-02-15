using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	//public float upright = 0.9f; // upright position, 90 degrees. Estupido.It isn't 0 b/c that ain't a quaternion, FOOL
	public float standingThreshold = 3f; // the upright position - this = rotation deemed as not upright enough

	public GameObject alley;
	public GameObject sensor;

	void Update() {
 
	}

	public bool isUpright() {

		///My version
		/*
		float min = upright - standingThreshold;
		float max = upright + standingThreshold;

		if (transform.rotation.x > min && transform.rotation.x < max) { // Looks at the pin and determines if they are within the range of the standing threshold
			return true; //if it is within the threshold, YES, its true
		} else {
			return false; // else, not
		*/



		///Ben's version

		/*
		Vector3 rotationInEuler = transform.rotation.eulerAngles; // Converts the rotation to use euler angles (like you see in the inspector) instead of quaternion shart

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x); // gives the absolute value (which is x = positive x, regardless of the symbol)
		float tiltInZ = Mathf.Abs(rotationInEuler.z); //so we can use it in the if statement (below)
 		
		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) { // if tilt is less than the standing threshold, meaning it is not upright
			return true;
			print (gameObject.name + " stand u");
		} else {
			return false;
			print (gameObject.name + " no stand u");

 		}
		return true;
*/


		////Tom_bk's Version from his 

		Quaternion rotation = transform.rotation; //makes a quaternion for the rotation instead of a euler angles thing
		float absoluteX = Mathf.Abs(rotation.x); //gets the absolute value of the x rotation from the rotation var
		float absoluteZ = Mathf.Abs(rotation.z); //gets the absolute value of the z rotation from the rotation var
		
		Quaternion absouteRotation = new Quaternion(absoluteX, rotation.y, absoluteZ, rotation.w);  //creates a new quaternion using the absolute x and z but the same y and w from the rotation var
		
		Vector3 angle = absouteRotation.eulerAngles; // turns absolute rotation into a eulerangles thing
		
		if (angle.x < standingThreshold && angle.z < standingThreshold) // if the the rotation on z or x of Vector3 Angle (which is basically just the rotation with absolute values) is less than the standingThreshold, true
			return true;
		else
			return false; //but if it is greater, FALSE!!
		
	}

}

