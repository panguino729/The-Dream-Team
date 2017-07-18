using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

	private InventorySystem _inventory;


	// Use this for initialization
	void Start () {
		_inventory = GameObject.Find ("InventoryManager").GetComponent<InventorySystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && _inventory.hasItem((GameObject)Resources.Load ("Prefabs/Key"))) {
			_inventory.removeItem ((GameObject)Resources.Load ("Prefabs/Key"));
			GameObject.Find ("Main Camera").transform.Find ("SlidingDoorAudio").GetComponent<AudioSource> ().Play ();
			Destroy (this.gameObject);
		}
	}
}
