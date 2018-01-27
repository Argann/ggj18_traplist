using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe gérant les items pouvant être ramassés pour gagner des pièges
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour {

    /// <summary>
    /// Piège à gagner si le joueur ramasse l'item
    /// </summary>
    [SerializeField]
    private Piege contenu;

    public Piege Contenu {
        get { return contenu; }
        set { contenu = value; }
    }


    private Animator anim;


    void Start() {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        // Si le drone entre en collision avec l'item
        if (coll.CompareTag("Player")) {
            // Quel joueur contrôle actuellement le personnage ?
            int player = coll.transform.parent.GetComponent<CharacterBehavior>().Player;
            // On ajoute le piège a son inventaire
            Inventories.AddTrap(contenu, player);
            // Et on supprime l'item
            anim.SetBool("taken", true);
        }
    }

    public void Blow() {
        Destroy(gameObject);
    }
}
