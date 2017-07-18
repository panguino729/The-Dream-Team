using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerControls : MonoBehaviour {
	private Rigidbody2D rb;// stores Rigidbody component of the player, useful for movement with the function MovePosition()
	private int projectileDirection;// variable stores the last direction the character was facing, so the axe will be thrown in that direction
	public float initialHP;// variable stores starting hp, depending on class?
	public float moveSpeed;// variable stores movement speed, depending on class?
	public float projectileDamage;// variable stores character's damage, depending on class?
	public float projectileSpeed;// variable stores speed of characters shots, depending on class?
	public GameObject projectile;//Don't forget to select the object in unity, depending on class? Might remove depending on how classes work.
	private float xComponent;
	private float yComponent;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		//you can remove this line if you want, i just kept forgetting to change the character's movement speed
		if (moveSpeed == 0) {
			moveSpeed = 1;
		}
		if (projectileSpeed == 0) {
			projectileSpeed = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		Move();
	}

	//function for movement
	void Move(){
		//8 Directions possible to move, Axe
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				projectileDirection = 135;
				//Code to move them towards top left
				rb.velocity = new Vector3(-1, 1, 0);
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				projectileDirection = 45;
				//Code to move them towards top right
				rb.velocity = new Vector3(1, 1, 0);
			}
			else {
				projectileDirection = 90;
				//Code to move them up
				rb.velocity = new Vector3(0, 1, 0);
				}
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				projectileDirection = 225;
				//Code to move them towards bottom left
				rb.velocity = new Vector3(-1, -1, 0);
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				projectileDirection = 315;
				//Code to move them towards bottom right
				rb.velocity = new Vector3(1, -1, 0);
			} else {
				projectileDirection = 270;
				//Code to move them down
				rb.velocity = new Vector3(0, -1, 0);
			}
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			projectileDirection = 180;
			//Code to move them left
			rb.velocity = new Vector3(-1, 0, 0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			projectileDirection = 0;
			//Code to move them right
			rb.velocity = new Vector3 (1, 0, 0);
		} 
		else {
			rb.velocity = new Vector3 (0, 0, 0);
		}
		if (projectileDirection == 0) {
			xComponent = 1;
			yComponent = 0;
		}
		rb.velocity = rb.velocity * moveSpeed;
		if (projectileDirection == 45){
			xComponent = 1;
			yComponent = 1;
		}
		if (projectileDirection == 90) {
			xComponent = 0;
			yComponent = 1;
		}
		if (projectileDirection == 135) {
			xComponent = -1;
			yComponent = 1;
		}
		if (projectileDirection == 180) {
			xComponent = -1;
			yComponent = 0;
		}
		if (projectileDirection == 225) {
			xComponent = -1;
			yComponent = -1;
		}
		if (projectileDirection == 270) {
			xComponent = 0;
			yComponent = -1;
		}
		if (projectileDirection == 315) {
			xComponent = 1;
			yComponent = -1;
		}

		if (Input.GetKey (KeyCode.Return)) {
			if (GameObject.FindGameObjectsWithTag (projectile.tag).Length == 0) {
				GameObject newProjectile = Instantiate (projectile);
				newProjectile.transform.position = transform.position;
				newProjectile.transform.Rotate (0, 0, projectileDirection);
				newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(xComponent * projectileSpeed, yComponent * projectileSpeed, 0);
				newProjectile.GetComponent<projectileScript> ().shooter = this.gameObject.tag;
				newProjectile.GetComponent<projectileScript> ().procDamage = projectileDamage;
				this.transform.Find ("LaserGun").GetComponent<AudioSource>().Play();
			}
		}
	}
}
