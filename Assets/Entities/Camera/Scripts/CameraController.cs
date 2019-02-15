
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject ObjectToFollow;
	public float stopDistance;
	private Vector3 Offset;
	// Use this for initialization
	void Start () {
 		Offset = new Vector3 (this.transform.position.x - ObjectToFollow.transform.position.x, transform.position.y - ObjectToFollow.transform.position.y, transform.position.z  - ObjectToFollow.transform.position.z);//
		//negates the  ball by the position to get the offset.
		// Basically, this moves the camera backwards in a position relative to the ball or whatever is being followed
		//This is added 
	}
	
	// Update is called once per frame
	void Update () {
		if (ObjectToFollow.transform.position.z < stopDistance){ //sets this object to follow the object to follow with an offset, stops following if the ball reaches stop distance
			this.transform.position = ObjectToFollow.transform.position + Offset; //folows object to follow W/ offset
		}
	}
}
