using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {

    public int scoreValue;

	public void IncrementScore()
    {
        GameController.currentScore = GameController.currentScore + scoreValue;
    }
}
