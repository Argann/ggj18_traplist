using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    private AudioSource sfxSrc;

    public AudioSource SfxSrc {
        get { return sfxSrc; }
        set { sfxSrc = value; }
    }

    public static SoundManager instance;

    [SerializeField]
    private List<AudioClip> sauts;

    public List<AudioClip> Sauts {
        get { return sauts; }
        set { sauts = value; }
    }

    [SerializeField]
    private AudioClip mort;

    public AudioClip Mort {
        get { return mort; }
        set { mort = value; }
    }

    [SerializeField]
    private AudioClip mineBoom;

    public AudioClip MineBoom {
        get { return mineBoom; }
        set { mineBoom = value; }
    }

    [SerializeField]
    private AudioClip mineInstall;

    public AudioClip MineInstall {
        get { return mineInstall; }
        set { mineInstall = value; }
    }

    [SerializeField]
    private AudioClip item;

    public AudioClip Item {
        get { return item; }
        set { item = value; }
    }





    void Awake() {
        sfxSrc = GetComponent<AudioSource>();
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void PlayClip(AudioClip audio) {
        sfxSrc.PlayOneShot(audio);
    }

}
