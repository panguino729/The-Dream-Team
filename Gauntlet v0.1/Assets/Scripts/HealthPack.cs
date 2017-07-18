using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

	[SerializeField]
	private float _healAmount;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			coll.GetComponent<Player_Health> ().SetHealth (_healAmount + coll.GetComponent<Player_Health> ().GetHealth());
			coll.transform.Find("Medkit").GetComponent<AudioSource> ().Play ();
			Destroy (this.gameObject);
		}
	}
}
