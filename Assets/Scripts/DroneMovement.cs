using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour {
	public float speed;
    private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		//Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw ("HorizontalP2");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw ("VerticalP2");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);
	}
}
