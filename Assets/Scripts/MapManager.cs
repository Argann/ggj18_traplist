using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	public GameObject[] tiles = new GameObject[9];
	private static int[] left = {0,1,2};
	private static int[] right = {6,7,8};
	private static int[] top = {0,3,6};
	private static int[] bottom = {2,5,8};
	private static int centre = 4;

	private static float MAP_WIDTH = 9f;
	private static float MAP_HEIGHT = 9f;

	private static GameObject[] staticTiles = new GameObject[9];
	void Start() {
		staticTiles = tiles;
	}

	public static void TranslateMap(Collider2D dest) {
		Vector3 currentPos = staticTiles[centre].transform.position;
		Vector3 destPos = dest.transform.position;
		if (destPos.x < currentPos.x) MoveRightTiles();
		if (destPos.x > currentPos.x) MoveLeftTiles();
		if (destPos.y < currentPos.y) MoveTopTiles();
		if (destPos.y > currentPos.y) MoveBottomTiles();
	}
	
	private static void MoveLeftTiles() {
		for (int i = 0; i < left.Length; i++) {
			staticTiles[left[i]].transform.position = new Vector2(staticTiles[left[i]].transform.position.x + (3 * MAP_WIDTH), staticTiles[left[i]].transform.position.y);
			left[i] = (left[i] + 3) % 9;
			right[i] = (right[i] + 3) % 9;
		}
		int tmp = top[0];
		top[0] = top[1];
		top[1] = top[2];
		top[2] = tmp;
		tmp = bottom[0];
		bottom[0] = bottom[1];
		bottom[1] = bottom[2];
		bottom[2] = tmp;
		Rearrange();
		UpdateColliders();
	}

	private static void MoveRightTiles() {
		for (int i = 0; i < right.Length; i++) {
			staticTiles[right[i]].transform.position = new Vector2(staticTiles[right[i]].transform.position.x - (3 * MAP_WIDTH), staticTiles[right[i]].transform.position.y);
			right[i] = (right[i] + 6) % 9;
			left[i] = (left[i] + 6) % 9;
		}
		int tmp = top[2];
		top[2] = top[1];
		top[1] = top[0];
		top[0] = tmp;
		tmp = bottom[2];
		bottom[2] = bottom[1];
		bottom[1] = bottom[0];
		bottom[0] = tmp;
		Rearrange();
		UpdateColliders();
	}

	private static void MoveTopTiles() {
		for (int i = 0; i < top.Length; i++) {
			staticTiles[top[i]].transform.position = new Vector2(staticTiles[top[i]].transform.position.x, staticTiles[top[i]].transform.position.y - (3 * MAP_HEIGHT));
			top[i] = (top[i] + 1) % 9;
			bottom[i] = (bottom[i] + 1) % 9;
		}
		int tmp = left[0];
		left[0] = left[1];
		left[1] = left[2];
		left[2] = tmp;
		tmp = right[0];
		right[0] = right[1];
		right[1] = right[2];
		right[2] = tmp;
		Rearrange();
		UpdateColliders();
	}

	private static void MoveBottomTiles() {
		for (int i = 0; i < bottom.Length; i++) {
			staticTiles[bottom[i]].transform.position = new Vector2(staticTiles[bottom[i]].transform.position.x, staticTiles[bottom[i]].transform.position.y + (3 * MAP_HEIGHT));
			bottom[i] = (bottom[i] + 8) % 9;
			top[i] = (top[i] + 8) % 9;
		}
		int tmp = left[2];
		left[2] = left[1];
		left[1] = left[0];
		left[0] = tmp;
		tmp = right[2];
		right[2] = right[1];
		right[1] = right[0];
		right[0] = tmp;
		Rearrange();
		UpdateColliders();
	}

	public static GameObject GetCurrentCentre() {
		return staticTiles[centre];
	}

	private static void Rearrange() {
		int sum = top[0] + top[1] + top[2]
				+ left[1] + right[1]
				+ bottom[0] + bottom[1] + bottom[2];
		centre = 36 - sum;
	}

	public static GameObject GetTileAt(Vector3 tilePos) {
		foreach (GameObject current in staticTiles) {
			Vector3 currentPos = current.transform.position;
			if ((tilePos.x <= (currentPos.x + (MAP_WIDTH/2))) &&
				(tilePos.x > (currentPos.x - (MAP_WIDTH/2))) &&
				(tilePos.y <= (currentPos.y + (MAP_HEIGHT/2))) &&
				(tilePos.y > (currentPos.y - (MAP_HEIGHT/2))))
					return current;
		}
		return GetCurrentCentre();
	}

	public static void Reinit() {
		left[0] = 0;
		left[1] = 1;
		left[2] = 2;

		right[0] = 6;
		right[1] = 7;
		right[2] = 8;

		top[0] = 0;
		top[1] = 3;
		top[2] = 6;

		bottom[0] = 2;
		bottom[1] = 5;
		bottom[2] = 8;
		
		centre = 4;
	}

	private static void UpdateColliders() {
		foreach (GameObject tile in staticTiles) {
			tile.GetComponent<Collider2D>().enabled = true;
		}
		staticTiles[centre].GetComponent<Collider2D>().enabled = false;
	}
}
