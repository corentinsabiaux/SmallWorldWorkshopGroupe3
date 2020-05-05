using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Race
{
    public enum RacePhase
    {
        Actual,
        Declin,
        Ancestral
    }

    public enum RaceType
    {
        Amazones,
        Elven,
        Dwarf,
        Orcs,
        Giants,
        Skaven,
        Humans,
        Skeleton, //Ajout de la race type Skeleton.
        Salamander, //Ajout de la race type Salamander.
        nothing
    }

    public string name;
    public string desc;
    public RacePhase phase { get; set; }
    public RaceType type { get; set; }
    public int victoryPointAtPick { get; set; }

    public int troopsNumber { get; set; }
    public int troopsUsed { get; set; }
    public int troopsMax { get; set; }

    public abstract void StartTurn(Player p);
    public abstract bool CanConquest(int boardPos, Player p);
    public abstract void ConquestCost(int boardPos, ref int cost, Player p);
    public abstract void Conquest(int boardPos, Player p);
    public abstract int VictoryPointGain(Player p);
    public abstract void EndTurn(Player p);
    public abstract void LoosConquestedCase(int boardPos, Player p);
    public abstract void Declin(Player p);

}
