using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {
	
	private InventorySystem _inventory;

	private string _keyPrefabName;


	// Use this for initialization
	void Start () {
		_inventory = GameObject.Find ("InventoryManager").GetComponent<InventorySystem> ();
		_keyPrefabName = "Prefabs/Key";
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && _inventory.canAddItem ()) {
			_inventory.addItem ((GameObject)Resources.Load (_keyPrefabName));
			coll.transform.Find("pickKey").GetComponent<AudioSource> ().Play ();
			Destroy (this.gameObject);
		}
	}
}
