using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Merchant : Power
{
    public Merchant()
    {
        name = "Mineur";
        desc = "Prenez 1 jeton de victoire supplémentaire pour chaque région que vous occupez en fin de tour.";
        imagePath = "Power/Gold_digger";
        troopsNumber = 2;
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

        return p.conquestedCase.Count;
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
