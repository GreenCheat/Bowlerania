using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster2 {
	public enum Action {Tidy /*Tell us to tidy (y'know, remember the animation we made)*/,
						Reset /*Tell us to reset (y'know, remember the animation we made)?*/, 
						EndTurn /*Ends the current frame.*/,
						EndGame /*Will end the current game.*/,
						Undefined /*Wtf is the current action?? If you get this, you are #@$!ed.*/}; 
																
	public static Action NextAction (List<int> rolls) { //a new enumerator part of enum action. 
													    //It contains a list (like an array, but less @#!$ed up, you can add to it etc).
														//This list gives us the information  for the frame, the frame number and amount of pins knock'd
		Action nextAction = Action.Undefined; //We add nextAction. The value of nextaction is returned by the very similarly named NextAction to determine what to do based on the points u get

		for (int i = 0; i < rolls.Count; i++) { //Cycles through all the frames/rolls
			
			if (i == 20) {
				nextAction = Action.EndGame;
			} else if ( i >= 18 && rolls[i] == 10 ){ // Handle last-frame special cases
				nextAction = Action.Reset;
			} else if ( i == 19 ) {
				if (rolls[18]==10 && rolls[19]==0) {
					nextAction = Action.Tidy;
				} else if (rolls[18] + rolls[19] == 10) {
					nextAction = Action.Reset;
				} else if (rolls [18] + rolls[19] >= 10) {  // Roll 21 awarded
					nextAction = Action.Tidy;
				} else {
					nextAction = Action.EndGame;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (rolls[i] == 10) {
					rolls.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = Action.EndTurn;
				} else {
					nextAction = Action.Tidy;
				}
			} else { // Second bowl of frame
				nextAction = Action.EndTurn;
			}
		}
		
		return nextAction;
	}
}