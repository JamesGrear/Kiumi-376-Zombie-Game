using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZombieScript : MonoBehaviour {


	public float health = 100f;
	public float speed = 2f;

	public Tilemap walls;
	public GameObject targetPlayer;
	PathfindGrid pathfindingGrid;
	List<Point> path;
	GameLogic gameLogic;

	// Use this for initialization
	void Start () {

		InvokeRepeating("CalculatePath", 0f, 0.1f);
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");
		walls = GameObject.FindGameObjectWithTag ("WallsTilemap").GetComponent<Tilemap>();
		gameLogic = GameObject.FindObjectOfType<GameLogic> ();

		BoundsInt bounds = walls.cellBounds;
		Tile[] allTiles = walls.GetTiles<Tile> ();
		bool[,] wallsArray = new bool[bounds.size.x, bounds.size.y];

		for (int x = 0; x < bounds.size.x; x++) {
			for (int y = 0; y < bounds.size.y; y++) {
				
				Tile tile = allTiles [x + y * bounds.size.x];

				if (tile != null) {
					//Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name + " ct:" + tile.colliderType);
					if (tile.colliderType == Tile.ColliderType.None) {
						wallsArray[x,y] = true;
					} else if (tile.colliderType == Tile.ColliderType.Sprite) {
						wallsArray[x,y] = false;
					}
				} else {
					//Debug.Log("x:" + x + " y:" + y + " tile: (null)");
				}
			}
		}        

		pathfindingGrid = new PathfindGrid (wallsArray);
	}

	// Update is called once per frame
	void Update () {

		/*if (path.Count <= 0) {
			Debug.Log ("No path found.");
		} else {
			Debug.Log ("Path Found:");
			for (int i = 0; i < path.Count; i++) {
				Debug.Log (path [i].x + ", " + path[i].y);
			}
		}*/


		// move along path
		float step = speed * Time.deltaTime;
		BoundsInt bounds = walls.cellBounds;
		Vector3 start = walls.CellToWorld(new Vector3Int(path[0].x + bounds.min.x, path[0].y + bounds.min.y, 1));
		start = start + new Vector3 (0.5f, 0.5f);

		transform.position = Vector3.MoveTowards(transform.position, start, step);
			
	}

	void CalculatePath() {

		// calculate zombie and target player position in cells
		BoundsInt bounds = walls.cellBounds;

		Vector3Int zombieCellPosition = walls.WorldToCell (transform.position);
		zombieCellPosition.x = zombieCellPosition.x - bounds.min.x;
		zombieCellPosition.y = zombieCellPosition.y - bounds.min.y;
		Vector3Int playerCellPosition = walls.WorldToCell (targetPlayer.transform.position);
		playerCellPosition.x = playerCellPosition.x - bounds.min.x;
		playerCellPosition.y = playerCellPosition.y - bounds.min.y;

		Point from = new Point(zombieCellPosition.x, zombieCellPosition.y);
		Point to = new Point(playerCellPosition.x, playerCellPosition.y);

		// get path
		// path will either be a list of Points (x, y), or an empty list if no path is found.
		path = Pathfinding.FindPath(pathfindingGrid, from, to);

	}

	void OnDrawGizmos() {

		BoundsInt bounds = walls.cellBounds;

		for (int i = 1; path != null && i < path.Count; i++)
		{
			//Vector3 start = walls.CellToWorld(new Vector3Int(path[i].x + bounds.min.x, path[i].y + bounds.min.y, 1));
			Vector3 start = walls.CellToWorld(new Vector3Int(path[i].x + bounds.min.x, path[i].y + bounds.min.y, 1));
			start = start + new Vector3 (0.5f, 0.5f);
			Vector3 finish = walls.CellToWorld (new Vector3Int(path [i-1].x + bounds.min.x, path [i-1].y + bounds.min.y, 1));
			finish = finish + new Vector3 (0.5f, 0.5f);
			Gizmos.DrawLine(start, finish);
			Gizmos.DrawCube (start, new Vector3 (0.5f, 0.5f));
		}

	}

	public void TakeDamage(float damage) {
		
		health -= damage;

		if (health <= 0) {
			DestroyObject (gameObject);
			gameLogic.zombiesLeft--;
		}
	}
}
