using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FromCave : Power
{
    public FromCave()
    {
        name = "Des caves";
        desc = "";
        troopsNumber = 5;
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
        if (GameManager.Instance.board.boardCases[boardPos].adventage == BoardCase.CaseAdventage.Cave || GameManager.Instance.board.boardCases[boardPos].adventage2 == BoardCase.CaseAdventage.Cave)
        {
            cost--;
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

    }

    public override void LoosConquestedCase(int boardPos, Player p)
    {

    }

    public override void Declin(Player p)
    {

    }
}
