using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 temp = player.transform.position;
		temp.z = temp.z - 1.5f;
		// Assign value to Camera position
		transform.position = temp;
	}
}
