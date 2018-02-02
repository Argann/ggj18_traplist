using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour {
	public Canvas stdCanvas;
	public Canvas pauseCanvas;

	public static int nbDeathsP1 = 0;
	public static int nbDeathsP2 = 0;

	public static SystemManager instance;

	// Use this for initialization
	void Start () {
		stdCanvas.enabled = true;
		pauseCanvas.enabled = false;
		instance = this;
	}
	
	public void Pause() {
		Time.timeScale = 1 - Time.timeScale;
		pauseCanvas.enabled = !pauseCanvas.enabled;
	}

	public void RedirectHome() {
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
