using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad : Power
{
    public Nomad()
    {
        name = "Nomad";
        desc = "";
        troopsNumber = 5;
        turnConquest = 0;
    }
    public int turnConquest;
    public override void StartTurn(Player p)
    {
        turnConquest = 0;
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
        turnConquest++;
        Debug.Log("waw");
    }
    public override int VictoryPointGain(Player p)
    {
        int gain = turnConquest * 3;
        gain -= p.conquestedCase.Count;
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
