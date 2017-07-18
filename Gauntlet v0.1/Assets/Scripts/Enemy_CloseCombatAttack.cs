using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CloseCombatAttack : MonoBehaviour {

	[Tooltip("Seconds between attacks")]
	[SerializeField]
	private float coolDownPeriodInSeconds = 1;

	[Tooltip("Damage done per attack")]
	[SerializeField]
	private int attackDamage = 1;

	private float _timeStamp;

	//If it stays in a triggerboxCollider, then the player will take attackDamage ever coolDownPeriodInSeconds
	void OnTriggerStay2D(Collider2D coll) {
		if (isOffCooldown ()) {
			if (coll.gameObject.tag == "Player") {
				Debug.Log ("test");
				coll.GetComponent<Player_Health> ().Damage (attackDamage);
				_timeStamp = Time.time + coolDownPeriodInSeconds;
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
