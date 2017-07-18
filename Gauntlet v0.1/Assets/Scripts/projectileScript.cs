using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {
	public string shooter;
	public float procDamage;
	public GameObject shooterObject;


	// Use this for initialization
	void Start () {
		Destroy (this, 2f);
	}
		
	// Update is called once per frame
	void Update () {
		if (!GetComponent<SpriteRenderer> ().isVisible) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		
		Debug.Log (coll.name);

		if (coll.gameObject.tag != shooter) {
			if (coll.gameObject.tag == "Enemy") {
				coll.GetComponent<Enemy_Health> ().Damage (procDamage);
				if (shooter == "Enemy") {
					shooterObject.GetComponent<Demon_Shooting> ().shot = false;
				}
				Destroy (this.gameObject);
			} else if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Item") {
				if (shooter == "Enemy") {
					shooterObject.GetComponent<Demon_Shooting> ().shot = false;
				}
				Destroy (this.gameObject);
				//Add for shooting food/magic potions
			} else if (coll.gameObject.tag == "Player") {
				coll.GetComponent<Player_Health> ().Damage (procDamage);
				if (shooter == "Enemy") {
					shooterObject.GetComponent<Demon_Shooting> ().shot = false;
				}
				Destroy (this.gameObject);
			} else if (coll.gameObject.tag == "Generator" && shooter == "Player") {
				coll.GetComponent<Generator_Health> ().Damage (procDamage);
				Destroy (this.gameObject);
			}
		}
	}
}
