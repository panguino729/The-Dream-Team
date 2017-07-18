using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Magic : MonoBehaviour {

	[SerializeField]
	private int magicDmg;
	private InventorySystem _inventory;

	private List<GameObject> affectedEnemies;
	private List<GameObject> affectedGenerator;

	// Use this for initialization
	void Start () {
		_inventory = GameObject.Find ("InventoryManager").GetComponent<InventorySystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {

			if (_inventory.hasItem ((GameObject)Resources.Load("Prefabs/MagicPotion"))) {
				_inventory.removeItem ((GameObject)Resources.Load("Prefabs/MagicPotion"));
				doMagicDamage ();
				this.transform.Find ("PotionSound").GetComponent<AudioSource>().Play();
			}
		}
	}

	void doMagicDamage() {
		
		affectedEnemies = GameObject.FindGameObjectsWithTag ("Enemy").ToList();
		affectedGenerator = GameObject.FindGameObjectsWithTag ("Generator").ToList();

		for (int i = 0; i < affectedEnemies.Count; i++) {
			if(affectedEnemies [i].GetComponent<SpriteRenderer> ().isVisible){
				affectedEnemies [i].GetComponent<Enemy_Health> ().Damage (magicDmg);	
			}
		}

		for (int i = 0; i < affectedGenerator.Count; i++) {
			if (affectedGenerator [i].GetComponent<SpriteRenderer> ().isVisible) {
				affectedGenerator [i].GetComponent<Generator_Health> ().Damage (magicDmg);
			}
		}

	}
}
