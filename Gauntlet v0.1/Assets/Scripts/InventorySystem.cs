using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class InventorySystem : MonoBehaviour {

	public GameObject[] inventory;
	public GameObject[] cSlots;
	public Slot[] slotScripts;

	[SerializeField]
	private GameObject _drawnCanvas;

	[SerializeField]
	private GameObject _slotPrefab;

	int inventorySize = 12;
	int slotSize = 12;


	// Use this for initialization
	void Start () {
		inventory = new GameObject [inventorySize];
		cSlots = new GameObject [slotSize];
		slotScripts = new Slot [slotSize];

		int setSlotID = 0;
		for (int i = 0; i < slotSize; i++) {
			GameObject spawnedSlot = Instantiate (_slotPrefab);
			spawnedSlot.transform.SetParent (_drawnCanvas.transform);
			cSlots [i] = spawnedSlot;
			slotScripts [i] = cSlots [i].GetComponent<Slot> ();
			slotScripts [i].slotID = setSlotID;
			setSlotID++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Might not work
	public bool hasItem(GameObject search) {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == search) {
				return true;
			}
		}
		return false;
	}

	public void removeItem(GameObject search) {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == search) {
				inventory [i] = null;
				slotScripts[i].slotItem = null;
			}
		}
	}

	public void addItem(GameObject add) {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == null) {
				inventory [i] = add;
				slotScripts[i].slotItem = add;
				i = inventory.Length;
				//return true;
			}
		}
		//return false;
	}

	public bool canAddItem() {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == null) {
				return true;
			}
		}
		return false;
	}
}
	
