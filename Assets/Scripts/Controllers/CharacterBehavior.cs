using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script permettant de gérer le comportement du personnage
/// en fonction des inputs joueurs.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBehavior : GenericController {
    
    /// <summary>
    /// Vitesse de déplacement du personnage
    /// </summary>
    [SerializeField]
    private float speed;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    /// <summary>
    /// Rigidbody2D du personnage
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Est-ce la première frame d'appui sur la touche action ?
    /// </summary>
    private bool is_jump_down;

    /// <summary>
    /// Numéro du saut actuel, afin de limiter le double saut.
    /// </summary>
    private int jump_nb;

    /// <summary>
    /// Force du saut du personnage
    /// </summary>
    [SerializeField]
    private float jumpForce;

    public float JumpForce {
        get { return jumpForce; }
        set { jumpForce = value; }
    }


    public void Start () {
        base.LoadSwap();
        // Récupération du Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Le personnage commence sur le sol, il n'est donc pas en train de faire un saut.
        jump_nb = 0;

        // Le joueur contrôlant le personnage n'appuie par défaut pas sur "saut"
        is_jump_down = false;
	}
	

	void Update () {

        // Récupération de la vélocité en fonction de l'axe du joueur
        rb.velocity = new Vector2(Input.GetAxisRaw("HorizontalP"+player) * speed, rb.velocity.y);

        // Est-ce que le joueur touche le sol sur sa droite ou sa gauche ?
        Collider2D isGrounded_left = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.down, 1f, LayerMask.GetMask("Objects")).collider;
        Collider2D isGrounded_right = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, 1f, LayerMask.GetMask("Objects")).collider;

        bool isGrounded = isGrounded_left || isGrounded_right;

        // S'il touche le sol, alors on reset son nombre de saut
        if (isGrounded) {
            jump_nb = 0;
        }

        // Si le joueur appuie sur la touche action
        if (Input.GetAxisRaw("ActionP"+player) > 0) {

            // Si c'est la première frame où il le fait
            if (!is_jump_down) {

                // Et s'il n'a pas déjà fait de double saut,
                if (jump_nb <= 0) {

                    // On le fait sauter
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jump_nb++;
                    is_jump_down = true;
                }
                
            }
        
            // S'il n'appuie plus sur la touche action, alors on reset la variable d'état.
        } else {
            is_jump_down = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Pieges") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
