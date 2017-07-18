using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	private int _numTeleporters;
	private GameObject[] _teleporterGameObjectArray;
	private int _closestInArray;
	private float _distance;
	private GameObject _closestTeleporter;
	private int _offset;

	[SerializeField]
	private GameObject _player;

	private float _xOffset = 4f;
	private float _chosenX;

	private float _yOffset = 4f;
	private float _chosenY;

	private Vector3 _toSpawnLocation;

	private int _minusPlusX;
	private int _minusPlusY;


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			for (int z = 0; z < 50; z++) {
				FindNearestTeleporter ();

				_minusPlusX = Random.Range (1, 3);
				if (_minusPlusX == 1) {
					_chosenX = _xOffset;
				} else if (_minusPlusX == 2) {
					_chosenX = -_xOffset;
				} else if (_minusPlusX == 3) {
					_chosenX = 0;
				}

				_minusPlusY = Random.Range (1, 3);
				if (_minusPlusY == 1) {
					_chosenY = _yOffset;
				} else if (_minusPlusY == 2) {
					_chosenY = -_yOffset;
				} else if (_minusPlusY == 3 && _minusPlusX != 3) {
					_chosenY = 0;
				} else {
					//_chosenX
				}
				
				_toSpawnLocation = new Vector3 (_chosenX + _closestTeleporter.transform.position.x, _chosenY + _closestTeleporter.transform.position.y, 0);
				//Debug.Log (_closestTeleporter.transform.position);

				if (!isOccupied (_toSpawnLocation)) {
					GetComponent<AudioSource> ().Play();
					coll.transform.position = _toSpawnLocation;
					z = 50;

				}
			}
		}
	}

	void FindNearestTeleporter() {
		_numTeleporters = GameObject.FindGameObjectsWithTag ("Teleporter").Length;
		_teleporterGameObjectArray = GameObject.FindGameObjectsWithTag ("Teleporter");
		//finding itself in array. Obviously nearest


		//Debug.Log (_teleporterGameObjectArray [0].transform.position);
		//Debug.Log (_teleporterGameObjectArray [1].transform.position);
		if (_teleporterGameObjectArray [0] != this.gameObject) {
			_distance = Vector2.Distance (_teleporterGameObjectArray [0].transform.position, this.transform.position);
		} else if(_teleporterGameObjectArray [1] != this.gameObject) {
			_distance = Vector2.Distance (_teleporterGameObjectArray [1].transform.position, this.transform.position);
		}
			
		_closestInArray = 0;

		//Goes through GameObject, see's which GameObject has the shortest distance between this object and it
		for (int i = 0; i < _teleporterGameObjectArray.Length; i++) {
			//_distance = Vector2.Distance (_teleporterGameObjectArray [i].transform.position, this.transform.position);

			if (Vector2.Distance (_teleporterGameObjectArray [i].transform.position, this.transform.position) <= _distance && _teleporterGameObjectArray [i] != this.gameObject) {
				_closestInArray = i;
			}

		}

		//Defines the player closest to the gameObject as _closestPlayer
		_closestTeleporter = _teleporterGameObjectArray [_closestInArray];
	}

	bool isOccupied(Vector3 _placeToSpawn) {
		Vector2 colliderSize = _player.GetComponent<BoxCollider2D> ().offset;

		//Debug.Log (_enemy.GetComponent<BoxCollider2D>().size.y);
		//Debug.Log (_enemy.GetComponent<BoxCollider2D>().size.x);
		float top = _placeToSpawn.y + (_player.GetComponent<BoxCollider2D>().size.y / 2f);
		float btm = _placeToSpawn.y - (_player.GetComponent<BoxCollider2D>().size.y / 2f);
		float left = _placeToSpawn.x- (_player.GetComponent<BoxCollider2D>().size.x / 2f);
		float right = _placeToSpawn.x + (_player.GetComponent<BoxCollider2D>().size.x /2f);

		Vector3 topLeft = new Vector3( left, top, 0);
		Vector3 btmRight = new Vector3( right, btm, 0); 

		//This Might be able to be improved
		if (Physics2D.OverlapArea (topLeft, btmRight) != null) {
			return true;
		} else {
			return false;
		}
	}
		
}
