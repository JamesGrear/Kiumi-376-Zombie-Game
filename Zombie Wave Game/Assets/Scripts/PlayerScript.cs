using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D body;
	public GameObject bulletPrefab;
	public float speed;

	float moveHorizontal;
	float moveVertical;
	Vector2 positionOnScreen;
	Vector2 mouseOnScreen;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get the Screen positions of the player
		positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		//Get the Screen position of the mouse
		mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//Set the angle of the player to face the mouse
		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90));
	}

	void FixedUpdate() {

		//Store the current horizontal input in the float moveHorizontal.
		moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		moveVertical = Input.GetAxis ("Vertical");

		if (Input.GetMouseButtonDown(0) == true) {
			Fire();
		}

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal * speed * 0.1f, moveVertical * speed * 0.1f);

		// Move the player by this new vector
		body.MovePosition(body.position + movement);
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	void Fire() {
		// Create the Bullet
		var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

		float angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);

		//bullet.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angle));

		// Add velocity to the bullet

		var rad = angle * Mathf.Deg2Rad;

		var speed = bullet.GetComponent<BulletScript>().speed;

		//Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
		Vector2 bulletMovement = new Vector2(Mathf.Cos(rad) * speed, Mathf.Sin(rad) * speed);

		bullet.GetComponent<Rigidbody2D> ().velocity = bulletMovement;

	}
		
}
