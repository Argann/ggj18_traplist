using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour {

    private Piege contenu;

    public Piege Contenu {
        get { return contenu; }
        set { contenu = value; }
    }


    void OnTriggerEnter2D(Collider2D coll) {
        // Si le drone entre en collision avec l'item
        if (coll.CompareTag("Drone")) {
            coll.GetComponent<DroneBehavior>().AddTrap(contenu);
            Destroy(gameObject);
        }
    }
}
