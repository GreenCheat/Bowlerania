using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {
	
	public static List <int> scoreCumulative(List<int> rolls){
		List<int> cumulativeScores = new List<int> ();//makes a list that will be modified and returned by this ol' method
		int total = 0; // the total amount of score from this frame and from the past frames (the cumalative amount)

		foreach (int frameScore in frameScores(rolls)) {
			total += frameScore; //increase the total cumulative score
			cumulativeScores.Add (total); //ad this to the lsit
		}

		return cumulativeScores;
	}

	public static List<int> frameScores (List <int> rolls) {
		List<int> frameList = new List<int> ();
		int bonus = 0;

		for (int i = 0; i < rolls.Count; i += 2) { //counts  by 2 (2 rolls is one frame)

			if (rolls [i - 1] == 10) { //STRIKE! (bowl a perfect 10 on the first roll!

			} else if (rolls [i - 1] + rolls [i] == 10) {

			} else {
				bonus = 0;
			}

			frameList.Add (rolls [i - 1] + rolls [i] + bonus);
		}



		return frameList;


	}
}

// 1,5 (6)
// 2,5 (13)