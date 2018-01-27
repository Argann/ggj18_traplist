using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : Piege {

    [SerializeField]
    private ParticleSystem ps;

    void Awake() {
        ps.Stop();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Explode() {
        ps.Play();
		Destroy(gameObject);
	}
}
