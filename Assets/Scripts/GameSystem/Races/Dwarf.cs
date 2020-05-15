using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dwarf : Race
{
    public Dwarf()
    {
        name = "Esprit";
        desc = "Vous obtenez 1 jeton de victoire supplémentaire en fin de tour par Mine occupée. Ce pouvoir reste actif après le déclin.";
        imagePath = "Race/Placeholder_avis";
        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 3;
        troopsUsed = 0;
        troopsMax = 8;
        type = RaceType.Dwarf;
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
        int vPoint = 0;
        foreach (int i in p.conquestedCase)
        {
            if (GameManager.Instance.board.boardCases[i].adventage == BoardCase.CaseAdventage.Caverne || GameManager.Instance.board.boardCases[i].adventage2 == BoardCase.CaseAdventage.Caverne)
            {
                vPoint++;
            }
        }
        return vPoint;
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
