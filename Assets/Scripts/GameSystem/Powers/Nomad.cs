using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad : Power
{
    public Nomad()
    {
        name = "Nomad";
        desc = "";
        troopsNumber = 5;
        turnConquest = 0; 
    }
    public int turnConquest; //Ajout de la variable turnConquest pour gérer l'ajout de points à chacune des conquêtes.
    public override void StartTurn(Player p)
    {
        turnConquest = 0; //On remet turnConquest à 0 au début du tour car le pouvoir n'est pris en compte que durant le tour actuel.
    }
    public override bool CanConquest(int boardPos, Player p)
    {
        return false;
    }
    public override void ConquestCost(int boardPos, ref int cost, Player p)
    {
        
    }
    public override void Conquest(int boardPos, Player p)
    {
        turnConquest++; //Chaque territoires conquis ajoute 1 point dans turnConquest.
    }
    public override int VictoryPointGain(Player p)
    {
        int gain = turnConquest + turnConquest; //Ajout de la variable gain qui prends en compte turnConquest + turnConquest pour toujours avoir l'ajout de 2 points par territoires conquis.
        gain -= p.conquestedCase.Count; //Vous ne gagnez pas de points de victoire à la fin du tour par territoires conquis.
        return gain; //On retourne la valeur de gain au joueur.
    }

    public override void EndTurn(Player p)
    {

    }

    public override void LoosConquestedCase(int boardPos, Player p)
    {

    }

    public override void Declin(Player p)
    {

    }
}
