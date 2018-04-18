using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	GameObject[] spawnPoints;
	GameObject[] activeZombies;
	public GameObject zombie;
	public Text waveText;
	public int wave = 1;
	public int zombiesLeft = 10;
	public int maxZombies = 5;

	// Use this for initialization
	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag ("ZombieSpawn");
		InvokeRepeating("SpawnZombies", 2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

		if (zombiesLeft <= 0) {
			wave++;
			waveText.text = "Wave: " + wave;
			zombiesLeft = Mathf.CeilToInt(Mathf.Sqrt (wave)) * 10;
			maxZombies = 5 + wave;
		}
			
	}

	void SpawnZombies() {

		activeZombies = GameObject.FindGameObjectsWithTag ("Zombie");
		var spawn = Mathf.RoundToInt (Random.Range (0, spawnPoints.Length));
		GameObject spawnPoint = spawnPoints [spawn];

		if (activeZombies.Length < maxZombies) {
			Instantiate (zombie, spawnPoint.gameObject.transform.position, Quaternion.identity);
		}
	}

	public void NewGame() {
		wave = 1;
		zombiesLeft = 10;
		maxZombies = 5;
		waveText.text = "Wave: " + wave;
	}

	public void GameOver() {
		Invoke ("GameOverLogic", 3f);
	}

	void GameOverLogic() {
		
	}


}
