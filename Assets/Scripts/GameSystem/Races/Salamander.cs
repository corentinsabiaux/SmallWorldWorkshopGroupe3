using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salamander : Race
{ 
    public Salamander()
    {
        name = "Salamanders";
        desc = "";

        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 6;
        troopsUsed = 0;
        troopsMax = 11;
        type = RaceType.Salamander;
        nitroToken = 0;
    }
    public int nitroToken { get; set; }
    public override void StartTurn(Player p)
    {

    }
    public override bool CanConquest(int boardPos, Player p)
    {
        return false;
    }
    public override void ConquestCost(int boardPos, ref int cost, Player p)
    {
        int nitroUsed = 0;
        if (nitroUsed >= nitroToken)
        {
            cost -= nitroUsed;
        }
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
        foreach (int i in p.conquestedCase)
        {
            if (GameManager.Instance.board.boardCases[i].adventage == BoardCase.CaseAdventage.Mine || GameManager.Instance.board.boardCases[i].adventage2 == BoardCase.CaseAdventage.Mine)
            {
                nitroToken++;
            }
        }
    }
    public override void LoosConquestedCase(int boardPos, Player p)
    {
        
    }
    public override void Declin(Player p)
    {

    }
}
