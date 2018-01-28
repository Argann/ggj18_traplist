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
    /// Animator du personnage
    /// </summary>
    [SerializeField]
    private Animator anim;

    /// <summary>
    /// Est-ce la première frame d'appui sur la touche action ?
    /// </summary>
    private bool is_jump_down;

    /// <summary>
    /// Est-ce la première frame d'appui sur la touche bas ?
    /// </summary>
    private bool is_down_down;

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

    private List<Collider2D> colls;


    public void Start () {
        base.LoadSwap();
        // Récupération du Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Le personnage commence sur le sol, il n'est donc pas en train de faire un saut.
        jump_nb = 0;

        // Le joueur contrôlant le personnage n'appuie par défaut pas sur "saut"
        is_jump_down = false;

        is_down_down = false;
	}
	

	void Update () {

        float horizontal = Input.GetAxisRaw("HorizontalP" + player);

        float vertical = Input.GetAxisRaw("VerticalP" + player);

        // Désactivation OneWayPlatform, si on appuie sur "bas"
        if (vertical > 0.9f) {

            if (!is_down_down) {

                GameObject[] gol = GameObject.FindGameObjectsWithTag("OneWay");

                foreach (GameObject go in gol) {
                    go.GetComponent<Collider2D>().enabled = false;
                }

                is_down_down = true;
            }

            
        } else {

            if (is_down_down) {
                
                GameObject[] gol = GameObject.FindGameObjectsWithTag("OneWay");

                foreach (GameObject go in gol) {
                    go.GetComponent<Collider2D>().enabled = true;
                }

                is_down_down = false;
            }
            
        }

        // Récupération de la vélocité en fonction de l'axe du joueur
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Changement de l'animation du personnage
        anim.SetBool("run", horizontal != 0);

        // Flip du personnage en fonction de l'input
        if (horizontal > 0f) {
            transform.localScale = new Vector2(1f, 1f);
        } else if (horizontal < 0f) {
            transform.localScale = new Vector2(-1f, 1f);
        }

        // Est-ce que le joueur touche le sol sur sa droite ou sa gauche ?
        Collider2D isGrounded_left = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.down, 1.4f, LayerMask.GetMask("Objects")).collider;
        Collider2D isGrounded_right = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, 1.4f, LayerMask.GetMask("Objects")).collider;

        bool isGrounded = isGrounded_left || isGrounded_right;

        anim.SetBool("onGround", isGrounded);

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

                    SoundManager.instance.PlayClip(SoundManager.instance.Sauts[Random.Range(0, SoundManager.instance.Sauts.Count)]);
                }
                
            }
        
            // S'il n'appuie plus sur la touche action, alors on reset la variable d'état.
        } else {
            is_jump_down = false;
        }
        
        anim.SetBool("doubleSaut", jump_nb == 1);

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Pieges") {
            SoundManager.instance.PlayClip(SoundManager.instance.Mort);
            other.GetComponent<BombBehaviour>().Explode();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Tiles") {
            // Ici, comparer position du joueur et des Tiles pour savoir si top, bot, left, right
            if (transform.position.x < (other.transform.position.x - (other.bounds.size.x / 2))) {
                MapManager.MoveLeftTiles();
                Debug.Log("Entree par la gauche !");
            }
            if (transform.position.x > (other.transform.position.x + (other.bounds.size.x / 2))) {
                MapManager.MoveRightTiles();
                Debug.Log("Entree par la droite !");
            }
            if (transform.position.y < (other.transform.position.y - (other.bounds.size.y / 2))) {
                MapManager.MoveBottomTiles();
                Debug.Log("Entree par le bas !");
            }
            if (transform.position.y > (other.transform.position.y + (other.bounds.size.y / 2))) {
                MapManager.MoveTopTiles();
                Debug.Log("Entree par le haut !");
            }
        }
    }
}
