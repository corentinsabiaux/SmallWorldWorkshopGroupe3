using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Giants : Race
{
    public Giants()
    {
        name = "Giants";
        desc = "";

        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 6;
        troopsUsed = 0;
        troopsMax = 11;
        type = RaceType.Giants;
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
        BoardCase b = GameManager.Instance.board.boardCases[boardPos];
        bool haveMountain = false;
        foreach (int key in b.adjacenteCaseKeys)
        {
            if (GameManager.Instance.board.boardCases[key].type == BoardCase.CaseType.Mountain && GameManager.Instance.board.boardCases[key].playerNumber == p.playerNumber)
            {
                haveMountain = true;
            }
        }
        cost += haveMountain ? 1 : 0;
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
