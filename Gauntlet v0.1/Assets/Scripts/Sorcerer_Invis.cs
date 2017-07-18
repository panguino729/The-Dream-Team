using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer_Invis : MonoBehaviour {
	private float _timeStamp;

	[Tooltip("Seconds between switching states invis")]
	[SerializeField]
	private float _coolDownPeriodInSeconds = 1;

	private bool _isInvis = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isOffCooldown ()) {
			if (_isInvis) {
				_timeStamp = Time.time + _coolDownPeriodInSeconds;
				_isInvis = false;
				GetComponent<SpriteRenderer> ().enabled = true;
			} else {
				_timeStamp = Time.time + _coolDownPeriodInSeconds;
				_isInvis = true;
				GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}

	//returns whether it is off cooldown
	bool isOffCooldown(){
		if (_timeStamp <= Time.time) {
			return true;
		} else {
			return false;
		}
	}
}
