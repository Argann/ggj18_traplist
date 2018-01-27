using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    private static float delai = 20f;
	private static float cpt = 0f;
	private static float refreshFreq = 10f;

	private float width;

	public RawImage bar;
	public Text itemsP1;
	public Text itemsP2;

    public static float Delai {
        get { return delai; }
    }

	// Use this for initialization
	void Start () {
		width = bar.rectTransform.rect.width;
		InvokeRepeating("TimerUI", 1/refreshFreq, 1/refreshFreq);
	}
	
	// Update is called once per frame
	void Update () {
		itemsP1.text = "x " + (Inventories.Inventaires[1].Count).ToString();
		itemsP2.text = "x " + (Inventories.Inventaires[2].Count).ToString();
	}

	void TimerUI() {
		cpt = (cpt + (1/refreshFreq)) % delai;
		bar.rectTransform.sizeDelta = new Vector2(width - (cpt * width / delai), bar.rectTransform.rect.height);
	}
}
