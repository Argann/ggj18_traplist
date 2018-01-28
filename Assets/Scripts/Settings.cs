using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    private static float delai = 20f;

    public static float Delai {
        get { return delai; }
    }


    private static float cpt = 0f;

	private float width;

    public RectTransform canvas;
	public Image bar;
	public Text itemsP1;
	public Text itemsP2;
    

	// Use this for initialization
	void Start () {
        cpt = delai;
        width = canvas.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		itemsP1.text = "x " + (Inventories.Inventaires[1].Count).ToString();
		itemsP2.text = "x " + (Inventories.Inventaires[2].Count).ToString();

        if (cpt > 0f) {

            float prct = Mathf.InverseLerp(delai, 0 , cpt);

            float mdr = Mathf.Lerp(-288, -width, prct);

            bar.rectTransform.sizeDelta = new Vector2(mdr, bar.rectTransform.sizeDelta.y);

            cpt -= Time.deltaTime;
        } else {
            cpt = delai;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) Invoke("ReloadInTwoS", 2f);
	}

    private void ReloadInTwoS() {
        SceneManager.LoadScene(1);
    }

}
