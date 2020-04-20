using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Orcs : Race
{
    public Orcs()
    {
        name = "Orcs";
        desc = "";

        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 5;
        troopsUsed = 0;
        troopsMax = 10;
        type = RaceType.Orcs;
        tunrConquestCount = 0;
    }

    public int tunrConquestCount;

    public override void StartTurn(Player p)
    {
        tunrConquestCount = 0;
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
        if (GameManager.Instance.board.boardCases[boardPos].troopsNumber > 0 || GameManager.Instance.board.boardCases[boardPos].forgottenTribe > 0)
        {
            tunrConquestCount++;
        }
    }
    public override int VictoryPointGain(Player p)
    {
        return tunrConquestCount;
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
