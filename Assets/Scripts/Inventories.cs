using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventories {

    /// <summary>
    /// Inventaire des deux joueurs
    /// </summary>
    private static List<Piege>[] inventaires = new List<Piege>[3];

    public static List<Piege>[] Inventaires {
        get { return inventaires; }
    }

    /// <summary>
    /// Initialise les inventaires
    /// </summary>
    public static void Init() {
        inventaires[1] = new List<Piege>();
        inventaires[2] = new List<Piege>();
    }

    /// <summary>
    /// Permet d'ajouter un piège à l'inventaire du joueur défini
    /// </summary>
    /// <param name="piege">
    ///     Piège à ajouter à l'inventaire
    /// </param>
    /// <param name="player">
    ///     Joueur dont l'inventaire va être modifié
    /// </param>
    public static void AddTrap(Piege piege, int player) {
        inventaires[player].Add(piege);
    }

    /// <summary>
    /// L'inventaire du joueur est-il vide ?
    /// </summary>
    /// <param name="player">Joueur dont il faut checker l'inventaire</param>
    /// <returns></returns>
    public static bool IsEmpty(int player) {
        return inventaires[player].Count == 0;
    }

    /// <summary>
    /// Récupération du premier piège de l'inventaire du joueur
    /// </summary>
    /// <param name="player">Joueur dont il faut récupérer le premier piège de l'inventaire</param>
    /// <returns></returns>
    public static Piege GetTrap(int player) {
        return inventaires[player][0];
    }

    /// <summary>
    /// Supprimer le premier piège de l'inventaire du joueur
    /// </summary>
    /// <param name="player">Joueur dont il faut supprimer le premier piège de l'inventaire</param>
    public static void DeleteTrap(int player) {
        inventaires[player].RemoveAt(0);
    }
}
