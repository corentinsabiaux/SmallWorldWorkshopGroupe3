using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Elven : Race
{
    public Elven()
    {
        name = "Elefs";
        desc = "";

        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 6;
        troopsUsed = 0;
        troopsMax = 11;
        type = RaceType.Elven;
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

        return 0;
    }

    public override void EndTurn(Player p)
    {

    }

    public override void LoosConquestedCase(int boardPos, Player p)
    {
        p.troopsToRedeploy++;
    }

    public override void Declin(Player p)
    {

    }
}
