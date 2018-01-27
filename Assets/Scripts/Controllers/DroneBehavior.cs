using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script permettant de gérer le comportement du drone
/// en fonction des inputs joueurs.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class DroneBehavior : GenericController {

    /// <summary>
    /// ???
    /// </summary>
    public Piege TODELETE;

    /// <summary>
    /// Inventaire du drone
    /// </summary>
    
    // TODO : Faire un inventaire par joueur, et pas pour le drone
    private List<Piege> pieges = new List<Piege>();

    /// <summary>
    /// Vitesse de déplacement du drone
    /// </summary>
    public float speed;

    /// <summary>
    /// Rigidbody2D du Drone
    /// </summary>
    private Rigidbody2D rb2d;

	void Start () {
        // Instantiation des variables
		rb2d = GetComponent<Rigidbody2D> ();
        pieges.Add(TODELETE);
    }
	
	void Update () {
		//Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw ("HorizontalP"+player);

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw ("VerticalP"+player);

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, -moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);

        // Gestion de l'action
        float action = Input.GetAxisRaw("ActionP"+player);
        if (action != 0f && pieges.Count > 0) {
            Instantiate(pieges[0], transform.position, transform.rotation);
            pieges.RemoveAt(0);
        }
    }
}
