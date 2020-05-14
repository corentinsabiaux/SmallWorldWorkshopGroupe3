using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Humans : Race
{
    public Humans()
    {
        name = "Ferrailleur";
        desc = "Toute Dune occupé par vos Ferrailleur rapporte 1 jeton de victoire supplémentaire en fin de tour.";
        imagePath = "Race/Placeholder_avis";
        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 5;
        troopsUsed = 0;
        troopsMax = 10;
        type = RaceType.Humans;
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
            if (GameManager.Instance.board.boardCases[key].type == BoardCase.CaseType.Fileds){
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
