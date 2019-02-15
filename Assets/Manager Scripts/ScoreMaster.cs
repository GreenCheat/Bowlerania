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

	public static List<int> frameScores (List <int> scores) {
		List<int> frameList = new List<int>();



		return frameList;
	}
}

// 1,5 (6)
// 2,5 (13)