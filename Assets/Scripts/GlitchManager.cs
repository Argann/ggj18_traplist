using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

[RequireComponent(typeof(AnalogGlitch))]
public class GlitchManager : MonoBehaviour {

    private float baseScanLineJitter;
    private float baseVerticalJump;
    private float baseHorizontalShake;
    private float baseDolorDrift;

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

        AnalogGlitch ag = GetComponent<AnalogGlitch>();

        baseScanLineJitter = ag.scanLineJitter;
        baseVerticalJump = ag.verticalJump;
        baseHorizontalShake = ag.horizontalShake;
        baseDolorDrift = ag.colorDrift;
    }

    public void LaunchGlitch() {
        StartCoroutine(GlitchSwitch());
    }

    private IEnumerator GlitchSwitch() {

        AnalogGlitch ag = GetComponent<AnalogGlitch>();

        float cpt = 0;

        while (cpt < time / 2) {

            ag.scanLineJitter = Mathf.InverseLerp(baseScanLineJitter, time / 2, cpt);
            ag.verticalJump = Mathf.InverseLerp(baseVerticalJump, time / 2, cpt);
            ag.horizontalShake = Mathf.InverseLerp(baseHorizontalShake, time / 2, cpt);
            ag.colorDrift = Mathf.InverseLerp(baseDolorDrift, time / 2, cpt);

            cpt += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        cpt = 0;

        while (cpt < time / 2) {

            ag.scanLineJitter = Mathf.InverseLerp(time / 2, baseScanLineJitter, cpt);
            ag.verticalJump = Mathf.InverseLerp(time / 2, baseVerticalJump, cpt);
            ag.horizontalShake = Mathf.InverseLerp(time / 2, baseHorizontalShake, cpt);
            ag.colorDrift = Mathf.InverseLerp(time / 2, baseDolorDrift, cpt);

            cpt += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        ag.scanLineJitter = baseScanLineJitter;
        ag.verticalJump = baseVerticalJump;
        ag.horizontalShake = baseHorizontalShake;
        ag.colorDrift = baseDolorDrift;

    }
}
