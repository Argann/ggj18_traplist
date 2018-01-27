using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeplacementPersonnage : MonoBehaviour {

    [Range(1,2)]
    [SerializeField]
    private int player;

    public int Player {
        get { return player; }
        set { player = value; }
    }


    [SerializeField]
    private float speed;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    private Rigidbody2D rb;

    private bool is_jump_down;

    private int jump_nb;

    [SerializeField]
    private float jumpForce;

    public float JumpForce {
        get { return jumpForce; }
        set { jumpForce = value; }
    }


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        jump_nb = 0;
        is_jump_down = false;
	}
	
	// Update is called once per frame
	void Update () {

        // Traitement direction
        rb.velocity = new Vector2(Input.GetAxisRaw("HorizontalP"+player) * speed, rb.velocity.y);

        Collider2D isGrounded_left = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.down, 1f, LayerMask.GetMask("Objects")).collider;
        Collider2D isGrounded_right = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, 1f, LayerMask.GetMask("Objects")).collider;

        bool isGrounded = isGrounded_left || isGrounded_right;

        Debug.DrawRay(transform.position, Vector2.down);

        if (isGrounded) {
            jump_nb = 0;
        }

        // Traitement saut
        if (Input.GetAxisRaw("ActionP"+player) > 0) {

            if (!is_jump_down) {

                if (jump_nb <= 0) {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jump_nb++;
                    is_jump_down = true;
                }
                
            }

        } else {
            is_jump_down = false;
        }


    }
}
