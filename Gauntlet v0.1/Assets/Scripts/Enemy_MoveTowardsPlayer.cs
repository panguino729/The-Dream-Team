using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveTowardsPlayer : MonoBehaviour {

	[Tooltip("Speed of the Enemy")]
	[SerializeField]
	private float _speed = 1;

	private Vector3 _move;

	Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Moves enemy forward at speed
	void Update () {
		//See FacePlayer about visibility issues
		if (GetComponent<SpriteRenderer> ().isVisible) {
			transform.position += transform.right * _speed * Time.deltaTime;
		}
	}
}

