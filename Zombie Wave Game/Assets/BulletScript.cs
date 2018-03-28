using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//DestroyObject (gameObject);
		if (!collider.CompareTag("Player")) {
			DestroyObject (gameObject);
		}
	}
}
