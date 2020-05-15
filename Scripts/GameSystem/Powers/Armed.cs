using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Armed : Power
{
    public Armed()
    {
        name = "Milicien";
        desc = "Toute région peut-être conquise avec 1 pion de Peuple en moins que nécessaire, avec un minimum de 1 pion.";
        imagePath = "Power/Militiaman";
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
        cost--;
    }
    public override void Conquest(int boardPos, Player p)
    {

    }
    public override int VictoryPointGain(Player p)
    {
        return 0;
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
