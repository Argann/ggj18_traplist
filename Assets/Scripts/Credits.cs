using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Glitch");
	}
	
	IEnumerator Glitch() {
        while (true) {
            GlitchManager.instance.LaunchGlitch();
            yield return new WaitForSeconds(5);
        }
    }

    void Update() {
        if (Input.anyKey) {
            SceneManager.LoadScene(0);
        }
    }
}
