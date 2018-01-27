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

	private static float width = 45f;
	private static float height = 12f;

	private static GameObject[] staticTiles = new GameObject[9];
	void Start() {
		staticTiles = tiles;
	}

	public static void MoveLeftTiles() {
		staticTiles[left[0]].transform.position = new Vector2(staticTiles[left[0]].transform.position.x + (3 * width), staticTiles[left[0]].transform.position.y);
		staticTiles[left[1]].transform.position = new Vector2(staticTiles[left[1]].transform.position.x + (3 * width), staticTiles[left[1]].transform.position.y);
		staticTiles[left[2]].transform.position = new Vector2(staticTiles[left[2]].transform.position.x + (3 * width), staticTiles[left[2]].transform.position.y);
		left[0] = (left[0] + 3) % 9;
		left[1] = (left[1] + 3) % 9;
		left[2] = (left[2] + 3) % 9;
		right[0] = (right[0] + 3) % 9;
		right[1] = (right[1] + 3) % 9;
		right[2] = (right[2] + 3) % 9;
		centre = (centre + 3) % 9;
	}

	public static void MoveRightTiles() {
		staticTiles[right[0]].transform.position = new Vector2(staticTiles[right[0]].transform.position.x - (3 * width), staticTiles[right[0]].transform.position.y);
		staticTiles[right[1]].transform.position = new Vector2(staticTiles[right[1]].transform.position.x - (3 * width), staticTiles[right[1]].transform.position.y);
		staticTiles[right[2]].transform.position = new Vector2(staticTiles[right[2]].transform.position.x - (3 * width), staticTiles[right[2]].transform.position.y);
		right[0] = (right[0] + 6) % 9;
		right[1] = (right[1] + 6) % 9;
		right[2] = (right[2] + 6) % 9;
		left[0] = (left[0] + 6) % 9;
		left[1] = (left[1] + 6) % 9;
		left[2] = (left[2] + 6) % 9;
		centre = (centre + 6) % 9;
	}

	public static void MoveTopTiles() {
		staticTiles[top[0]].transform.position = new Vector2(staticTiles[top[0]].transform.position.x, staticTiles[top[0]].transform.position.y - (3 * height));
		staticTiles[top[1]].transform.position = new Vector2(staticTiles[top[1]].transform.position.x, staticTiles[top[1]].transform.position.y - (3 * height));
		staticTiles[top[2]].transform.position = new Vector2(staticTiles[top[2]].transform.position.x, staticTiles[top[2]].transform.position.y - (3 * height));
		top[0] = (top[0] + 1) % 9;
		top[1] = (top[1] + 1) % 9;
		top[2] = (top[2] + 1) % 9;
		bottom[0] = (bottom[0] + 1) % 9;
		bottom[1] = (bottom[1] + 1) % 9;
		bottom[2] = (bottom[2] + 1) % 9;
		centre = (centre + 1) % 9;
	}

	public static void MoveBottomTiles() {
		staticTiles[bottom[0]].transform.position = new Vector2(staticTiles[bottom[0]].transform.position.x, staticTiles[bottom[0]].transform.position.y + (3 * height));
		staticTiles[bottom[1]].transform.position = new Vector2(staticTiles[bottom[1]].transform.position.x, staticTiles[bottom[1]].transform.position.y + (3 * height));
		staticTiles[bottom[2]].transform.position = new Vector2(staticTiles[bottom[2]].transform.position.x, staticTiles[bottom[2]].transform.position.y + (3 * height));
		bottom[0] = (bottom[0] + 8) % 9;
		bottom[1] = (bottom[1] + 8) % 9;
		bottom[2] = (bottom[2] + 8) % 9;
		top[0] = (top[0] + 8) % 9;
		top[1] = (top[1] + 8) % 9;
		top[2] = (top[2] + 8) % 9;
		centre = (centre + 8) % 9;
	}

	public static GameObject GetCurrentCentre() {
		return staticTiles[centre];
	}
}
