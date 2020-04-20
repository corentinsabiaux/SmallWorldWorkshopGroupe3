using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power
{
    public string name;
    public string desc;

    public int troopsNumber { get; set; }

    public abstract void StartTurn(Player p);
    public abstract bool CanConquest(int boardPos, Player p);
    public abstract void ConquestCost(int boardPos, ref int cost, Player p);
    public abstract void Conquest(int boardPos, Player p);
    public abstract int VictoryPointGain(Player p);
    public abstract void EndTurn(Player p);
    public abstract void LoosConquestedCase(int boardPos, Player p);
    public abstract void Declin(Player p);
}
