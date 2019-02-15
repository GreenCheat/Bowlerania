using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class OurScoreDisplayTest {
	
		private List<int> pinFalls;
		private ActionMaster2.Action endTurn = ActionMaster2.Action.EndTurn;
		private ActionMaster2.Action tidy = ActionMaster2.Action.Tidy;
		private ActionMaster2.Action reset = ActionMaster2.Action.Reset;
		private ActionMaster2.Action endGame = ActionMaster2.Action.EndGame;

		[SetUp]
		public void Setup () {
			pinFalls = new List<int> ();
		}

		[Test]
		public void T00PassingTest () {
			Assert.AreEqual (1, 1);
		}

		[Test]
		public void T01OneStrikeReturnsEndTurn () {
			pinFalls.Add (10);
			Assert.AreEqual (endTurn, ScoreMaster.scoreCumulative (pinFalls.ToList()));
		}

		[Test]
		public void T02Bowl8ReturnsTidy () {
			pinFalls.Add (8);
			Assert.AreEqual (tidy, ScoreMaster.scoreCumulative (pinFalls.ToList()));
		}

		[Test]
		public void T04Bowl28SpareReturnsEndTurn () {
			int[] rolls = {2, 8};
			Assert.AreEqual (endTurn, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T05CheckResetAtStrikeInLastFrame () {
			int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
			Assert.AreEqual (reset, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T06CheckResetAtSpareInLastFrame () {
			int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
			Assert.AreEqual (reset, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T07YouTubeRollsEndInEndGame () {
			int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2, 9};
			Assert.AreEqual (endGame, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T08GameEndsAtBowl20 () {
			int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
			Assert.AreEqual (endGame, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T09DarylBowl20Test () {
			int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5};
			Assert.AreEqual (tidy, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T10BensBowl20Test () {
			int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};
			Assert.AreEqual (tidy, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T11NathanBowlIndexTest () {
			int[] rolls = {0,10, 5,1};
			Assert.AreEqual (endTurn,ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T12Dondi10thFrameTurkey () {
			int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10};
			Assert.AreEqual (endGame, ScoreMaster.scoreCumulative (rolls.ToList()));
		}

		[Test]
		public void T13ZeroOneGivesEndTurn () {
			int[] rolls = {0,1};
			Assert.AreEqual (endTurn, ScoreMaster.scoreCumulative (rolls.ToList()));
		}
}