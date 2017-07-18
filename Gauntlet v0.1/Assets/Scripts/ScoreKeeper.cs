using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private float _score;

	[SerializeField]
	private Text _scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddToScore(float addScoreAmount) {
		_score += addScoreAmount;
		UpdateScore ();
	}

	public void UpdateScore() {
		_scoreText.text = "Score = " + _score;
	}
}
