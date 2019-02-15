using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour {

	public static int amountPinsStanding() {
		int amount = 0; // amount of pins standing
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) { //finds all pin scripts by searching each and every one with findObjectsofType | Yes, Find can result in lag but this game is small as heck
			if (pin.isUpright()) { //detects if the pin is getting the isUpright signal
				amount++; 
			} //we dont need an "else" or "else if" because it isn't supposed to do anything
		}
		return amount; 
	}
}