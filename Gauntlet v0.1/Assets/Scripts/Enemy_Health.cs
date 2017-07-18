using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour {

	[Tooltip("Health of the Enemy")]
	[SerializeField]
	private float _health = 5;

	[Tooltip("Enemy's Score")]
	[SerializeField]
	private int _score = 1;

	[SerializeField]
	private GameObject _scoreKeeper;

	void Start() {
		_scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper"); 
	}

	//Handles damaging enemies, and removes them if they run out of health
	public void Damage(float damage) {
		_health -= damage;
		if (_health <= 0) {
			_scoreKeeper.GetComponent<ScoreKeeper> ().AddToScore (_score);
			Destroy (this.gameObject);
			//Increase player score
		}
	}
		
	//Getters and Setters for values inside this class
	public float GetHealth() {
		return _health;
	}

	public void SetHealth(float setHealth) {
		_health = setHealth;
	}

	public int GetScoreAmount() {
		return _score;
	}
}
