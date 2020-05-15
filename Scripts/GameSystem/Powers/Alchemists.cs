using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Alchemists : Power
{
    public Alchemists()
    {
        name = "Poudrier";
        desc = "Tant que votre Peuple n'est pas en déclin, vous obtenez 2 jetons de victoire supplémentaires à la fin de chaque tour.";
        imagePath = "Power/Powder_compact";
        troopsNumber = 4;
    }

    public override void StartTurn(Player p)
    {
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

    }
    public override int VictoryPointGain(Player p)
    {
        return 2;
    }

    public override void EndTurn(Player p)
    {

    }

    public override void LoosConquestedCase(int boardPos, Player p)
    {

    }

    public override void Declin(Player p){

    }
}
