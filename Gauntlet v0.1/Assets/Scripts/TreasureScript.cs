using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour {

	[SerializeField]
	private float _scoreAmount;

	[SerializeField]
	private GameObject _scoreKeeper;

	void Start() {
		_scoreKeeper = GameObject.FindGameObjectWithTag ("ScoreKeeper");
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			_scoreKeeper.GetComponent<ScoreKeeper> ().AddToScore (_scoreAmount);
			Destroy (this.gameObject);
		}
	}
}
