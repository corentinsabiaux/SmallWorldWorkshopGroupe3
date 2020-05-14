using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FromSwamp : Power
{
    public FromSwamp()
    {
        name = "Des Ranch";
        desc = "Prenez 1 jeton de victoire supplémentaire pour chaque Ranch que vous occupez en fin de tour.";
        imagePath = "Power/Ranch";
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
        int gain = 0;
        foreach (int key in p.conquestedCase)
        {
            if (GameManager.Instance.board.boardCases[key].type == BoardCase.CaseType.Swamp)
            {
                gain++;
            }
        }
        return gain;
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
