using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDrag : MonoBehaviour {
	
	public BallBehavior ball;
	private Vector3 dragstartPos;
	private Vector3 dragendPos; //The position the ball was in when it was first dragged AND the position the ball was in when it was let go

	private float timeStart;
	private float timeEnd;

 
	void Start(){
		ball = GetComponent<BallBehavior>();
	}

	public void DStart() {
		if (!ball.ballIsRolling) {
			dragstartPos = Input.mousePosition; // Assigns value to dragstartPos (see decleration)
			timeStart = Time.time; //gets current time to determine swipe output
			print ("drag started");
		}
	}

	public void DEnd() {
		if (!ball.ballIsRolling) {
			dragendPos = Input.mousePosition; // Assigns value to dragstartPos (see decleration)
			timeEnd = Time.time;
		
			float dragDuration = timeEnd - timeStart;
			float launchVelocityX = (dragendPos.x - dragstartPos.x) / dragDuration; //gets the velocity based on speed and position of drag
			float launchVelocityZ = (dragendPos.y - dragstartPos.y) / dragDuration; // tl:dr velocity based on dragging of ball

			Vector3 finalVelocity =  new Vector3 (launchVelocityX, 0, launchVelocityZ); // gets the velocity the ball will be launched
	 		if (ball.ballIsRolling == false) {
				ball.Roll (finalVelocity); // Rolls ball on end of drag, DUH
			}
		}
 	}
}