using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D body;
	public float speed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get the Screen positions of the player
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//Set the angle of the player to face the mouse
		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90));
	}

	void FixedUpdate() {

		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal * speed * 0.1f, moveVertical * speed * 0.1f);

		// Move the player by this new vector
		body.MovePosition(body.position + movement);
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
		
}
