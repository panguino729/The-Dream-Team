using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHatch : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			GetComponent<AudioSource> ().Play ();
			SceneManager.LoadScene("EndOfDemo", LoadSceneMode.Single);
		}
	}
}
