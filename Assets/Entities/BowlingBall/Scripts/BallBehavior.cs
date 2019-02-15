using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public Rigidbody rigidBody;
	public Vector3 launchSpeed;
	public Vector3 startingPos;
	public AudioSource ballRoll;

	public bool ballIsRolling = false;

	// Use this for initialization
	void Start () {
 		startingPos = this.transform.position; // assigns starting pos to the position the ball is in when the game is started
		rigidBody = GetComponent<Rigidbody> ();
		ballRoll = GetComponent<AudioSource>();
		rigidBody.useGravity = false; // it cannot move & crap

	}

	public void Roll(Vector3 velocity){
		rigidBody.useGravity = true; // 
		rigidBody.velocity = velocity;
		print ("Velocity, Rigidbody" + rigidBody.velocity);
		ballRoll.Play (0);
		ballIsRolling = true;

	}

	public void AdjustBall(float adjustmentForce) { //the ball moves according to the adjustment force /// THIS IS USED IN AN EVENT TRIGGER
		if (!ballIsRolling)
		transform.Translate (new Vector3 (adjustmentForce, 0, 0)); // moves the X pos by the adjustment force
		//print (Mathf.Clamp (this.transform.position.x, -780, -700));
 		//this.transform.position = new Vector3 (Mathf.Clamp (this.transform.position.x, -780, -700), this.transform.position.y,this.transform.position.z );
	}

	public void BallReset() {
		this.transform.position = startingPos; //resets position
		rigidBody.velocity = new Vector3 (0, 0, 0); //resets velocity
		rigidBody.angularVelocity = new Vector3 (0, 0, 0); //resets velocity
		this.transform.rotation = Quaternion.identity; //resets rotation
		ballIsRolling = false; // ball no longer rolling; makes it possible to fling the ball after reset
		rigidBody.useGravity = false; // it cannot move & crap when it is reset for flinging
	}
}
