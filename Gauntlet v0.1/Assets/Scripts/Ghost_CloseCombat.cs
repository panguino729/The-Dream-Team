using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_CloseCombat : MonoBehaviour {

	[Tooltip("Damage done per attack")]
	[SerializeField]
	private int attackDamage = 1;

	//If it stays in a triggerboxCollider, then the player will take attackDamage ever coolDownPeriodInSeconds
	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			//Player.damage(attackDamage);
			coll.GetComponent<Player_Health> ().Damage (attackDamage);
			Destroy (this.gameObject);
		}
	}
}

