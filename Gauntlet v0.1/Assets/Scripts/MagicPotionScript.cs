using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPotionScript : MonoBehaviour {

	private InventorySystem _inventory;

	private string _magicPotionPrefabName;


	// Use this for initialization
	void Start () {
		_inventory = GameObject.Find ("InventoryManager").GetComponent<InventorySystem> ();
		_magicPotionPrefabName = "Prefabs/MagicPotion";
	}

	// Update is called once per frame
	void Update () {

	}

	//Add Projectile. If trigger, does like 50% damage;
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && _inventory.canAddItem ()) {
			_inventory.addItem ((GameObject)Resources.Load (_magicPotionPrefabName));
			Destroy (this.gameObject);
		} 
	}
}
