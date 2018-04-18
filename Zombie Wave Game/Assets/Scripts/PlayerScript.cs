using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D body;
	public GameObject bulletPrefab;
	Animator animator;
	public Slider healthSlider;
	GameLogic gameLogic;

	float moveHorizontal;
	float moveVertical;
	Vector2 positionOnScreen;
	Vector2 mouseOnScreen;

	float maxHealth = 1000f;
	float health = 1000f;
	public float speed;

	bool isFiring = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		gameLogic = GameObject.FindObjectOfType<GameLogic> ();
		animator = GetComponent<Animator> ();
		healthSlider.value = 1;
	}
	
	// Update is called once per frame
	void Update () {

		// EXIT IF DEAD!
		if (health <= 0)
			return;
		
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

		// EXIT IF DEAD!
		if (health <= 0)
			return;

		//Store the current horizontal input in the float moveHorizontal.
		moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		moveVertical = Input.GetAxis ("Vertical");

		if (!isFiring) {
			if (moveHorizontal != 0 || moveVertical != 0) {
				animator.enabled = true;
				animator.Play ("Player_Walking");
			} else {
				animator.enabled = false;
			}
		}

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

		isFiring = true;

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

		animator.enabled = true;
		animator.Play ("Player_Shooting");
		Invoke ("StopFiringAnimation", 0.25f);

	}

	void StopFiringAnimation() {
		isFiring = false;
		animator.enabled = false;
		Debug.Log ("Test");
	}

	float CalculateHealthPercentage() {
		return health / maxHealth;
	}

	public void TakeDamage(float damage) {

		health -= damage;

		if (health <= 0) {
			animator.enabled = true;
			animator.Play ("Player_Death");
			Destroy (GetComponent<Rigidbody2D>());
			Destroy (GetComponent<Collider2D> ());
			GetComponent<SpriteRenderer> ().sortingLayerName = "Dead";
			DestroyObject (gameObject, 0.83f);
			gameLogic.GameOver ();
		}

		healthSlider.value = CalculateHealthPercentage ();

	}
		
}
