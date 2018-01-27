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

    public int Player {
        get { return player; }
        set { player = value; }
    }


}
