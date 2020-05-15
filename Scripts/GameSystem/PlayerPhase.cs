using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerPhase
{
    public abstract bool doAction(Player player, Action act);
    public abstract void Enter(Player player);
    public abstract void Exit();
    public Player player;
    public string phaseName;

}
