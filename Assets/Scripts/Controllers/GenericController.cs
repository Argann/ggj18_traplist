using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe permettant de gérer de manière globale les différents input des joueurs
/// </summary>
public class GenericController : MonoBehaviour {

    [SerializeField]
    private GlitchManager gm;

    [SerializeField]
    public DisplayPlayer[] pMention;

    /// <summary>
    /// Numéro du joueur contrôlant l'entité
    /// </summary>
    [Range(1, 2)]
    [SerializeField]
    protected int player;

    private float delai = Settings.Delai;

    protected DisplayPlayer dp;

    protected static int randomBegin = 0;

    public int Player {
        get { return player; }
        set { player = value; }
    }

    protected void LoadSwap()
    {
        // La fonction d'inversion des joueurs est appelée toute les <delai> secondes
        InvokeRepeating("SwapPlayers", delai, delai);
    }

    protected void SwapPlayers() {
        player = 3 - player;
        Invoke("DisplayMention", 0.5f);
        GlitchManager.instance.LaunchGlitch();
    }

    protected void EnablePause() {
        SystemManager.instance.Pause();
    }

    protected void DisplayMention() {
        dp = Instantiate(pMention[player-1], transform);
    }
}
