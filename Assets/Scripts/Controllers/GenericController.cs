using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe permettant de gérer de manière globale les différents input des joueurs
/// </summary>
public class GenericController : MonoBehaviour {

    /// <summary>
    /// Numéro du joueur contrôlant l'entité
    /// </summary>
    [Range(1, 2)]
    [SerializeField]
    protected int player;

    private float delai = 20f;

    public int Player {
        get { return player; }
        set { player = value; }
    }

    protected void LoadSwap()
    {
        // La fonction d'inversion des joueurs est appelée toute les <delai> secondes
        InvokeRepeating("SwapPlayers", delai, delai);
    }

    void SwapPlayers() {
        player = 3 - player;
    }
}
