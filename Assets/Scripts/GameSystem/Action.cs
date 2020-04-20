using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public enum ActionType
    {
        MapAction,
        DeckAction,
        UnselectAction,
        LastConquestAction,
        EndOfTurnAction,
        DeclinAction,
        StartConquestAction
        
    }
    public Action(ActionType type, int index, int number = -1)
    {
        this.type = type;
        this.index = index;
        this.number = number;
    }

    public ActionType type { get; }
    public int index { get; }
    public int number { get; }
}
