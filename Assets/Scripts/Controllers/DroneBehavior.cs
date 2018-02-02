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
    public GameObject BombObject;

    /// <summary>
    /// Vitesse de déplacement du drone
    /// </summary>
    public float speed;

    /// <summary>
    /// Rigidbody2D du Drone
    /// </summary>
    private Rigidbody2D rb2d;

    /// <summary>
    /// Hauteur maximale de la camera
    /// </summary>
    private const float MAX_H = 6f;

    /// <summary>
    /// Hauteur minimale de la camera
    /// </summary>
    private const float MIN_H = -MAX_H;

    /// <summary>
    /// Largeur maximale de la camera
    /// </summary>
    private const float MAX_V = 4.5f;

    /// <summary>
    /// Largeur minimale de la camera
    /// </summary>
    private const float MIN_V = -MAX_V;

    /// <summary>
    /// Objet camera
    /// </summary>
    private Camera came;

    /// <summary>
    /// Est-ce la première frame d'appui sur la touche action ?
    /// </summary>
    private bool is_action_down;

    /// <summary>
    /// Nombre initial de bombe pour le joueur 2
    /// </summary>
    private const int NB_BOMB_INIT = 12;

	void Start () {
        InitPlayer();
        base.LoadSwap();
        // Instantiation des variables
		rb2d = GetComponent<Rigidbody2D> ();
        Inventories.Init();
        for(int i = 0; i < NB_BOMB_INIT; i++) Inventories.AddTrap(BombObject, player);
        is_action_down = false;
        came = Camera.main;
    }
	
	void Update () {
        if(Time.timeScale > 0) {
            transform.rotation = base.transform.rotation;
            //Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = Input.GetAxisRaw ("HorizontalP"+player);

            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxisRaw ("VerticalP"+player);

            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2 (moveHorizontal, -moveVertical);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rb2d.AddForce (movement * speed);

            ManageBoundaries();

            // Gestion de l'action
            float action = Input.GetAxisRaw("ActionP"+player);
            if (action != 0f) {

                if (!is_action_down && !Inventories.IsEmpty(player)) {
                    GameObject instance = Instantiate(Inventories.GetTrap(player), transform.position, transform.rotation);
                    instance.transform.SetParent(MapManager.GetTileAt(instance.transform.position).transform);

                    Inventories.DeleteTrap(player);

                    is_action_down = true;
                }
                
            } else {
                is_action_down = false;
            }
        }
    }

    void ManageBoundaries() {
        float x_axis = 0f;
        float y_axis = 0f;
        if(transform.position.x < came.transform.position.x + MIN_H) {
            x_axis = 1f;
        }
        if(transform.position.x > came.transform.position.x + MAX_H) {
            x_axis = -1f;
        }
        if(transform.position.y < came.transform.position.y + MIN_V) {
            y_axis = 1f;
        }
        if(transform.position.y > came.transform.position.y + MAX_V) {
            y_axis = -1f;
        }
        rb2d.AddForce (new Vector2(x_axis, y_axis) * speed * 2f);
    }

    protected void InitPlayer() {
        if (randomBegin == 0) randomBegin = Random.Range(1,3);
        player = 3 - randomBegin;
        Invoke("DisplayMention", 0f);
    }
}
