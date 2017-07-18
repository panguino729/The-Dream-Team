using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Health : MonoBehaviour {

	[Tooltip("Health of the Generator")]
	[SerializeField]
	private float _health = 20;

	[Tooltip("Enemy's Score")]
	[SerializeField]
	private int _score = 1;

	[SerializeField]
	private int _level2Health = 10;

	[SerializeField]
	private int _level1Health = 5;

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
		} else if (_health <= _level1Health) {
			//Change spawner to level 1 spawns
		} else if (_health <= _level2Health) {
			//Change spawner to level 2 spawns
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
