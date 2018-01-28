using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : Piege {

    [SerializeField]
    private ParticleSystem ps;

    private Animator anim;

    void Awake() {
        ps.Stop();
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Activate() {
        GetComponent<CircleCollider2D>().enabled = true;
    }

	public void Explode() {
        anim.SetBool("explodes", true);
        ps.Play();
	}

    public void BLow() {
        Destroy(gameObject);
    }
}
