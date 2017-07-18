using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

	[Tooltip("Health of the Player")]
	[SerializeField]
	private float _health = 600;

	[Tooltip("Continual damage amount")]
	[SerializeField]
	private float _continualDamageAmount = 1;

	[Tooltip("Seconds between continual damage")]
	[SerializeField]
	private float coolDownPeriodInSeconds = 1;

	private float _timeStamp;

	[Tooltip("Displays Health")]
	[SerializeField]
	private Text _healthText;

	void Update() {
		if (isOffCooldown ()) {
			_timeStamp = Time.time + coolDownPeriodInSeconds;
			Damage (_continualDamageAmount);
		}
	}

	//Handles damaging enemies, and removes them if they run out of health
	public void Damage(float damage) {
		_health -= damage;
		_healthText.GetComponent<Text> ().text = "Health = " + _health;
		if (_health <= 0) {
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
		_healthText.GetComponent<Text> ().text = "Health = " + _health;
	}


	bool isOffCooldown(){
		if (_timeStamp <= Time.time) {
			return true;
		} else {
			return false;
		}
	}
}
