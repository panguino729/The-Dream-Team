using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

	private int _numPlayers;
	private GameObject[] _playerGameObjectArray;
	private int _closestInArray;
	private float _distance;
	private GameObject _closestPlayer;

	//TODO: update finding method for variables once a static config is created

	// Use this for initialization
	void Start () {
		//Will change into future once we have a static class with all the required variables, such as numPlayers


		_playerGameObjectArray = new GameObject[4];	//4 represents the "max" possible players
	}

	void FindNearestPlayer() {
		
		//Establishes number of players, puts them into an array, calculates the 
		_numPlayers = GameObject.FindGameObjectsWithTag ("Player").Length;
		_playerGameObjectArray = GameObject.FindGameObjectsWithTag ("Player");
		_distance = Vector2.Distance (_playerGameObjectArray [0].transform.position, this.transform.position);
		_closestInArray = 0;

		//Goes through GameObject, see's which GameObject has the shortest distance between this object and it
		for (int i = 0; i < _playerGameObjectArray.Length; i++) {
			if (Vector2.Distance (_playerGameObjectArray [i].transform.position, this.transform.position) < _distance) {
				_distance = Vector2.Distance (_playerGameObjectArray [i].transform.position, this.transform.position);
				_closestInArray = i;
			}

		}

		//Defines the player closest to the gameObject as _closestPlayer
		_closestPlayer = _playerGameObjectArray [_closestInArray];
			
	}

	// Update is called once per frame
	void Update () {

		//NOTE: This will return true if the scene camera is showing the object. Might be a problem in testing
		//To fix: check if the object is within the x and y range of the camera. This would bypass this problem.
		if (GetComponent<SpriteRenderer> ().isVisible) {
			FindNearestPlayer ();

			//Get's the vector between both vectors, then gets the angle of that vector
			int times = 0;
			Vector3 direction  = _closestPlayer.transform.position - this.transform.position;
			float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			//Keeps rot_z between 0 and 360
			if (rot_z < 0) {
				rot_z = 360 + rot_z;
			}

			//To keep it restricted at 45 degree intervals, must divide rot_z by 45 and round
			times = Mathf.RoundToInt (rot_z / 45);

			//Sets rotation of enemy to face player
			transform.rotation = Quaternion.Euler(0f, 0f, times * 45);
		}
	}
}
