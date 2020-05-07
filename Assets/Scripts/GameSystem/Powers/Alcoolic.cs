using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcoolic : Power
{
    public Alcoolic()
    {
        name = "Alcoolic";
        desc = "";
        imagePath = "Power/Alcoolic";
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
            if (GameManager.Instance.board.boardCases[key].adventage == BoardCase.CaseAdventage.Saloon) //pour chaque case saloon conquise
            {
                gain++; //on gagne 1 point
            }
        }
        return gain;
    }
    public override void EndTurn(Player p)
    {
        foreach (int key in p.conquestedCase)
        {
            if (GameManager.Instance.board.boardCases[key].adventage == BoardCase.CaseAdventage.Saloon) //pour chaque case saloon conquise
            {
                GameManager.Instance.board.boardCases[key].haveSaloon = true; //on met un jeton saloon qui défend
            }
            else
            {
                GameManager.Instance.board.boardCases[key].haveSaloon = false; //sinon on en met pas
            }
        }
    }
    public override void LoosConquestedCase(int boardPos, Player p)
    {

    }
    public override void Declin(Player p)
    {
        foreach (int key in p.conquestedCase)
        {
            GameManager.Instance.board.boardCases[key].haveSaloon = false; //on retire tout les jetons saloon qui défendent
        }
    }
}
