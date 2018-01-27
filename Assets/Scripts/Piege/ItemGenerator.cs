using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    /// <summary>
    /// Les items peuvent spawner dans une certaine range autour de la caméra.
    /// Cette range est définie ici.
    /// </summary>
    [SerializeField]
    private Vector2 range;

    public Vector2 Range {
        get { return range; }
        set { range = value; }
    }

    /// <summary>
    /// Liste d'items pouvant être instantiés
    /// </summary>
    [SerializeField]
    private List<GameObject> items;

    public List<GameObject> Items {
        get { return items; }
        set { items = value; }
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
                item_position = new Vector2(
                        Random.Range(Camera.main.transform.position.x - range.x, Camera.main.transform.position.x + range.x),
                        Random.Range(Camera.main.transform.position.y - range.y, Camera.main.transform.position.x + range.y)
                    );

                // Vérification emplacement plateforme
                correctPosition = !Physics2D.Raycast(item_position, Vector2.up, 0.1f, LayerMask.GetMask("Objects")).collider;

                // Attente de la frame suivante afin de ne pas bloquer dans une boucle infinie
                yield return new WaitForEndOfFrame();
            }
            
            // Une fois une position correcte trouvée, on instantie l'item.
            Instantiate(items[Random.Range(0, items.Count)], item_position, Quaternion.identity, MapManager.GetCurrentCentre().transform);

            // Après l'instantiation, on attend un temps aléatoire avant de faire spawner le suivant
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
	
	void Start() {
        StartCoroutine("Spawner");
    }
}
