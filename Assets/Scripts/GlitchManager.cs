using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

[RequireComponent(typeof(AnalogGlitch))]
public class GlitchManager : MonoBehaviour {


    [SerializeField]
    private float time;


    void Start() {
        StartCoroutine("GlitchSwitch");
    }

    private IEnumerator GlitchSwitch() {

        AnalogGlitch ag = GetComponent<AnalogGlitch>();

        while (true) {

            ag.scanLineJitter = 0;
            ag.verticalJump = 0;
            ag.horizontalShake = 0;
            ag.colorDrift = 0;

            yield return new WaitForSeconds(Settings.Delai);

            float cpt = 0;

            while (cpt < time / 2) {

                ag.scanLineJitter = Mathf.InverseLerp(0, time / 2, cpt);
                ag.verticalJump = Mathf.InverseLerp(0, time / 2, cpt);
                ag.horizontalShake = Mathf.InverseLerp(0, time / 2, cpt);
                ag.colorDrift = Mathf.InverseLerp(0, time / 2, cpt);

                cpt += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            cpt = 0;

            while (cpt < time / 2) {

                ag.scanLineJitter = Mathf.InverseLerp(time / 2, 0, cpt);
                ag.verticalJump = Mathf.InverseLerp(time / 2, 0, cpt);
                ag.horizontalShake = Mathf.InverseLerp(time / 2, 0, cpt);
                ag.colorDrift = Mathf.InverseLerp(time / 2, 0, cpt);

                cpt += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            
        }
        
    }
}
