﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCredits : MonoBehaviour {

	public void VersCredits() {
        SceneManager.LoadScene(2);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
