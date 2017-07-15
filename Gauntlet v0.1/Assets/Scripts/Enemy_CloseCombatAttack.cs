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

	private float timeStamp;

	//If it stays in a triggerboxCollider, then the player will take attackDamage ever coolDownPeriodInSeconds
	void OnCollisionStay2D(Collision2D coll) {
		if (isOffCooldown ()) {
			if (coll.gameObject.tag == "Player") {
				//Player.damage(attackDamage);
				timeStamp = Time.time + coolDownPeriodInSeconds;
			}
		}
	}

	//returns whether it is off cooldown
	bool isOffCooldown(){
		if (timeStamp <= Time.time) {
			return true;
		} else {
			return false;
		}
	}
}
