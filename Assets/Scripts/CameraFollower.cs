using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    [SerializeField]
    private GameObject character;

	// Update is called once per frame
	void Update () {
        if (character) {
            transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -10);
        }
	}
}
