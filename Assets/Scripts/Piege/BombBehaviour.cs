using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : Piege {

	// Use this for initialization
	void Start () {
		Invoke("Explode", 10);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Explode() {
		Debug.Log("BOOM");
		Destroy(gameObject);
	}
}
