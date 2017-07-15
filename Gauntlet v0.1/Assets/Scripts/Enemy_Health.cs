using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

	[Tooltip("Health of the Enemy")]
	[SerializeField]
	private int _health = 5;

	[Tooltip("Enemy's Score")]
	[SerializeField]
	private int _score = 1;

	//Handles damaging enemies, and removes them if they run out of health
	public void Damage(int damage) {
		_health -= damage;
		if (_health <= 0) {
			Destroy (this.gameObject);
			//Increase player score
		}
	}
		
	//Getters and Setters for values inside this class
	public int GetHealth() {
		return _health;
	}

	public void SetHealth(int setHealth) {
		_health = setHealth;
	}

	public int GetScoreAmount() {
		return _score;
	}
}
