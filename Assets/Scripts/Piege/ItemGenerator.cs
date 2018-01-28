using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    /// <summary>
    /// Les items peuvent spawner a certains points de spawn.
    /// Cette liste les contient tous.
    /// </summary>
    [SerializeField]
    private List<Transform> spawners;

    public List<Transform> Spawners {
        get { return spawners; }
        set { spawners = value; }
    }

    /// <summary>
    /// Liste d'items pouvant être instantiés
    /// </summary>
    [SerializeField]
    private GameObject item;

    public GameObject Item {
        get { return item; }
        set { item = value; }
    }

    /// <summary>
    /// Temps d'attente minimal entre chaque instantiation
    /// </summary>
    [SerializeField]
    private float minTime;

    public float MinTime {
        get { return minTime; }
        set { minTime = value; }
    }


    /// <summary>
    /// Temps d'attente maximal entre chaque instantiation
    /// </summary>
    [SerializeField]
    private float maxTime;

    public float MaxTime {
        get { return maxTime; }
        set { maxTime = value; }
    }

    IEnumerator Spawner() {
        while (true) {

            // Au début, aucune position correcte n'est trouvée
            bool correctPosition = false;
            Vector2 item_position = new Vector2();

            while (!correctPosition) {
                // Définition d'une position de spawn aléatoire autour de la caméra
                item_position = spawners[Random.Range(0,spawners.Count)].position;

                // Vérification emplacement plateforme
                correctPosition = !Physics2D.Raycast(item_position, Vector2.up, 0.1f, LayerMask.GetMask("Items")).collider;

                // Attente de la frame suivante afin de ne pas bloquer dans une boucle infinie
                yield return new WaitForEndOfFrame();
            }

            // Une fois une position correcte trouvée, on instantie l'item.
            Instantiate(item, item_position, Quaternion.identity, MapManager.GetCurrentCentre().transform);


            // Après l'instantiation, on attend un temps aléatoire avant de faire spawner le suivant
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
	
	void Start() {
        StartCoroutine("Spawner");
    }
}
