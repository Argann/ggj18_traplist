using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

[RequireComponent(typeof(AnalogGlitch))]
public class GlitchManager : MonoBehaviour {


    [SerializeField]
    private float time;


    public static GlitchManager instance;

    void Awake() {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
    }

    public void LaunchGlitch() {
        StartCoroutine(GlitchSwitch());
    }

    private IEnumerator GlitchSwitch() {

        Debug.Log("Launch");

        AnalogGlitch ag = GetComponent<AnalogGlitch>();

        float cpt = 0;

        while (cpt < time / 2) {

            ag.scanLineJitter = Mathf.InverseLerp(0, time / 2, cpt);
            ag.verticalJump = Mathf.InverseLerp(0, time / 2, cpt);
            ag.horizontalShake = Mathf.InverseLerp(0, time / 2, cpt);
            ag.colorDrift = Mathf.InverseLerp(0, time / 2, cpt);

            cpt += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        cpt = 0;

        while (cpt < time / 2) {

            ag.scanLineJitter = Mathf.InverseLerp(time / 2, 0, cpt);
            ag.verticalJump = Mathf.InverseLerp(time / 2, 0, cpt);
            ag.horizontalShake = Mathf.InverseLerp(time / 2, 0, cpt);
            ag.colorDrift = Mathf.InverseLerp(time / 2, 0, cpt);

            cpt += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        ag.scanLineJitter = 0;
        ag.verticalJump = 0;
        ag.horizontalShake = 0;
        ag.colorDrift = 0;

    }
}
