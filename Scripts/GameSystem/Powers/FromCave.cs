using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FromCave : Power
{
    public FromCave()
    {
        name = "Des mines";
        desc = "Toute région qui comporte une Mine peut-être conquise avec un pion du Peuple de moins que nécessaire, avec un minimum de 1 pion. Les Mines sont adjacentes entre elles.";
        imagePath = "Power/Cave";
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
        if (GameManager.Instance.board.boardCases[boardPos].adventage == BoardCase.CaseAdventage.Mine || GameManager.Instance.board.boardCases[boardPos].adventage2 == BoardCase.CaseAdventage.Mine)
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
