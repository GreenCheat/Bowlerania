using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	/////////////////////////////////////////////////////////////////////////////////////////////
	public static bool ballTouched = false; // not pervy, trust me you immature dimwit. basically what it says (not what you think), true if the ball has entered, false if it hasn't.

 
	public static Animator anim; 
	public GameObject cleaner; //tha pin swiper. and the variable name is immature-joke resistant. hooray	
	public GameObject pins; // the 10 pins, PREFAB
	/////////////////////////////////////////////////////////////////////////////////////////////
	void Start() {
		anim = gameObject.GetComponent<Animator> ();
		ballTouched = false; //intializes ball touched
	}
	/////////////////////////////////////////////////////////////////////////////////////////////
	void OnTriggerEnter(Collider col) { //col = object i collide with
		if (col.GetComponent<BallBehavior> ()) { // scans everything that enters and tries to find the ball behavior component
			ballTouched = true; // if it is there, then it is tha balll!!!
		} else {
			ballTouched = false;
		}
	}
	/////////////////////////////////////////////////////////////////////////////////////////////
	void OnTriggerExit (Collider col) { //if something exits me
		if (col.gameObject.transform.parent.GetComponent<Pin>()) { //If the object that has exited has a parent that has the pin script (meaning it is a pin)... 
			Destroy (col.gameObject.transform.parent.gameObject); //destroy said parent
		}
	}
 	//////////////////////////////////////////////////////////////////////////////////////////
	public void ElevatePins(float raiseDistance) { //raise pins by raiseDistance OR lowers them
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) { //finds all pin scripts by searching each and every one with findObjectsofType 
			if (pin.isUpright()) { //if the pin is standing up
				pin.transform.GetComponent<Rigidbody>().isKinematic = true;
				pin.transform.rotation = Quaternion.identity;
				pin.transform.Translate ( new Vector3 (0, raiseDistance, 0 ), Space.World );
			} // else it wont return anything
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////
	public void RenewPins() {
		Instantiate (pins, new Vector3 (-743.99f, -240.4412f, 1471.797f ), Quaternion.identity);
	}
	//////////////////////////////////////////////////////////////////////////////////////////
}