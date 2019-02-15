using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterballDetector : MonoBehaviour {

	void OnTriggerExit (Collider col) { //if something exits me
		PinSetter.ballTouched = true; //ballTouched is true, therefore triggering a reset of the pins in PinOverlord (see overlord script)
	}

}
