using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int lastUprightCount = -1; //the amount of pins that have stood upright last time. Set to -1 for initilization
	public  int lastSettledCount = 10; //the amount of pins that are upright and have settled on PinsHaveSettled TODO make me private
	public float lastChangeTime;
	private BallBehavior ball; // the ball //HA HA BALLS POO POO PEE PEE. Grow up. Seriously, Line 8 isn't funny anymore.
	public Text thaScore; // The thingy that displays the amount of pins that are still up

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<BallBehavior> (); //get ball
		thaScore.color = Color.black; // intializes the color of the upright pin count (b/c the count color will be altered)
	}
	
	// Update is called once per frame
	void Update () {
		if (PinSetter.ballTouched) { //if the ball has been touched before
			thaScore.color = Color.red; //make it red 
			CheckForUprightPins(); 	//checks if the pins are upright once the ball is bowled into the pins.
		} //Else? do nothin.
	}

	void CheckForUprightPins() { 		
		int currentlyStanding = PinCounter.amountPinsStanding (); // Gets how much pins are standing upright as of now
		if (currentlyStanding != lastUprightCount) {  // if there's a new amount of upright pins
			lastUprightCount = currentlyStanding; // update the last upright count to be the current standing count
			lastChangeTime = Time.time; // also update the time
			return;
		} 

		float settleTime = 3f; // length of time it takes to wait for the game to consider whether the pins are settled or not
		if ((Time.time - lastChangeTime) > settleTime) { // if the time since the last change is longer than how long it takes to settle
			PinsHaveSettled();
		}

		thaScore.text = PinCounter.amountPinsStanding ().ToString (); //start updating score, as we want the program to start updating score once the ball actually enters the pin area

	}
	/////////////////////////////////////////////////////////////////////////////////////////////
	void PinsHaveSettled() {
		int pinsNotStanding = lastSettledCount - PinCounter.amountPinsStanding(); //gets the amount of pins fell (reminder that lastSettledCount equals 10 at this point)
		lastSettledCount = PinCounter.amountPinsStanding(); //updates last settledcount
		List <int> pinsNotStandingList = new List <int>(); //Makes a list so it  can be processed by the actionmaster, which ONLY takes lists
		pinsNotStandingList.Add (pinsNotStanding);
		ActionMaster2.Action action = ActionMaster2.NextAction(pinsNotStandingList); //Makes an action based on pinsNotStandingList.

		switch (action) { //if action...
		case ActionMaster2.Action.Tidy: //
			PinSetter.anim.SetTrigger ("tidyTrigger");
			break;
		case ActionMaster2.Action.Reset: 
			PinSetter.anim.SetTrigger ("resetTrigger");
			break;
		case ActionMaster2.Action.EndGame: 
			throw new UnityException ("Implement the endgame fool");
			break;
		case ActionMaster2.Action.EndTurn: 
			PinSetter.anim.SetTrigger ("resetTrigger");
			break;
		}
			
		ball.BallReset (); //reset ball to old pos, removes velocity, etc
		lastUprightCount = -1; //Reintialization
		lastChangeTime = 0; ///Reintialization
		PinSetter.ballTouched = false; //Reintialization
		thaScore.color = Color.green; //make the text green b/c fun
		//Pin[] oldPins = FindObjectsOfType<Pin>(); //gets all the pins that exist
		//foreach (Pin pin in oldPins) {Destroy (pin.gameObject);} //Gets every pin in oldPins and destroys them
		//Instantiate (pins, this.transform.position, Quaternion.identity); //then make new ones!!
	}
}
