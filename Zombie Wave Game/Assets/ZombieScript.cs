using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZombieScript : MonoBehaviour {


	public float health = 100f;
	public Tilemap walls;
	public GameObject targetPlayer;
	PathfindGrid pathfindingGrid;

	// Use this for initialization
	void Start () {

		/*for (int x = 1; x <= wallsSize.x; x++) {
			for (int y = 1; y <= wallsSize.y; y++) {

				TileBase tileBase = walls.GetTile (new Vector3Int (x, y, 1));
				Tile tile = walls.GetTile<Tile>(new Vector3Int (x, y, 1));

				if (tile.colliderType == Tile.ColliderType.None) {
					wallsArray[x,y] = true;
				} else if (tile.colliderType == Tile.ColliderType.Sprite) {
					wallsArray[x,y] = false;
				}
			}
		}*/

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
		List<Point> path = Pathfinding.FindPath(pathfindingGrid, from, to);

		if (path.Count <= 0) {
			Debug.Log ("No path found.");
		} else {
			Debug.Log ("Path Found:");
			for (int i = 0; i < path.Count; i++) {
				Debug.Log (path [i].x + ", " + path[i].y);
			}
		}
	}

	public void TakeDamage(float damage) {
		
		health -= damage;

		if (health <= 0) {
			DestroyObject (gameObject);
		}
	}
}
