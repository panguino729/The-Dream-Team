using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Shooting : MonoBehaviour {

	public GameObject projectile;
	public bool shot = false;
	public float projectileSpeed;
	public float projectileDamage;
	public bool firstTime = true;
	public float timeStampStart;
	public float startTimerInSeconds = 1;

	public float minTimeBetweenShotsInSeconds = 1;
	public float shotsTimeStamp;


	void Start(){
		timeStampStart = Time.time + startTimerInSeconds; 
		shotsTimeStamp = 0;
	}

	// NOTE: first ever shot from an enemy doesn't actually spawn anything. No idea why
	void Update () {
		Debug.Log (isOffCooldown());
		if (isOnStart ()) {
			if (shot == false) {
				if (isOffCooldown ()) {

					GameObject newProjectile = Instantiate (projectile);
					newProjectile.transform.position = transform.position;
					newProjectile.transform.rotation = new Quaternion (this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, 0);
					newProjectile.GetComponent<Rigidbody2D> ().velocity = transform.right * projectileSpeed;
					Debug.Log (newProjectile.GetComponent<Rigidbody2D> ().velocity);
					newProjectile.GetComponent<projectileScript> ().shooter = this.gameObject.tag;
					newProjectile.GetComponent<projectileScript> ().procDamage = projectileDamage;
					newProjectile.GetComponent<projectileScript> ().shooterObject = this.gameObject;
					newProjectile.GetComponent<projectileScript> ().tag = this.gameObject.tag;

					if (!firstTime) {
						shot = true;
						shotsTimeStamp = Time.time + shotsTimeStamp;
					} else {
						firstTime = false;
					}
				}
			}
		}
	}

	bool isOnStart(){
		if (timeStampStart <= Time.time) {
			return true;
		} else {
			return false;
		}
	}

	bool isOffCooldown(){
		if (shotsTimeStamp <= Time.time) {
			return true;
		} else {
			return false;
		}
	}
}
