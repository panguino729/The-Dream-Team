using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Spawn : MonoBehaviour {

	[Tooltip("Seconds between spawns")]
	[SerializeField]
	private float coolDownPeriodInSeconds = 0.5f;

	[SerializeField]
	private GameObject _enemy;


	private float _timeStamp;

	private float _xOffset = 1.5f;
	private float _chosenX;

	private float _yOffset = 1.5f;
	private float _chosenY;

	private Vector3 _toSpawnLocation;

	private int _minusPlus;

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteRenderer> ().isVisible && isOffCooldown()) {
			_timeStamp = Time.time + coolDownPeriodInSeconds;

			_minusPlus = Random.Range (1, 3);
			if (_minusPlus == 1) {
				_chosenX = this.transform.position.x + _xOffset;
			} else if (_minusPlus == 2) {
				_chosenX = this.transform.position.x - _xOffset;
			} else if (_minusPlus == 3) {
				_chosenX = this.transform.position.x;
			}

			_minusPlus = Random.Range (1, 3);
			if (_minusPlus == 1) {
				_chosenY = this.transform.position.y + _yOffset;
			} else if (_minusPlus == 2) {
				_chosenY = this.transform.position.y - _yOffset;
			} else if (_minusPlus == 3) {
				_chosenY = this.transform.position.y;
			}

			_toSpawnLocation = new Vector3(_chosenX, _chosenY, 0);



			if (!isOccupied (_toSpawnLocation)) {
				GameObject spawnedEnemy = Instantiate (_enemy);
				spawnedEnemy.transform.position = _toSpawnLocation;
			} else {
				_timeStamp = Time.time;
			}
		}
	}

	bool isOffCooldown(){
		if (_timeStamp <= Time.time) {
			return true;
		} else {
			return false;
		}
	}

	//BoxCollider2D for attack may be factored into potential boxes. If this is the case and is a problem, add the attack to a child of the gameobject
	//Will not work right if boxcollider is not a square
	bool isOccupied(Vector3 _placeToSpawn) {
		Vector2 colliderSize = _enemy.GetComponent<BoxCollider2D> ().offset;

		Debug.Log (_enemy.GetComponent<BoxCollider2D>().size.y);
		Debug.Log (_enemy.GetComponent<BoxCollider2D>().size.x);
		float top = _placeToSpawn.y + (_enemy.GetComponent<BoxCollider2D>().size.y / 2f);
		float btm = _placeToSpawn.y - (_enemy.GetComponent<BoxCollider2D>().size.y / 2f);
		float left = _placeToSpawn.x- (_enemy.GetComponent<BoxCollider2D>().size.x / 2f);
		float right = _placeToSpawn.x + (_enemy.GetComponent<BoxCollider2D>().size.x /2f);

		Vector3 topLeft = new Vector3( left, top, 0);
		Vector3 btmRight = new Vector3( right, btm, 0); 

		//This Might be able to be improved
		if (Physics2D.OverlapArea (topLeft, btmRight) != null) {
			return true;
		} else {
			return false;
		}
	}

	/*IEnumerator Spawn() {
		
	}*/
}
