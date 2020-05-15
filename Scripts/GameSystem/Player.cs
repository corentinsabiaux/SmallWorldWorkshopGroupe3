using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using JetBrains.Annotations;

public class Player
{
    private List<Texture> tokentextures;
    public Player(int playerNumber)
    {
        this.playerNumber = playerNumber;
        victoryPoint = 5;
        phase = new SelectRaceAndPowerPhase();
        actualRace = null;
        actualPower = null;
        decliningRace = null;
        conquestedCase = new List<int>();
        conquestedCaseDeclin = new List<int>();
        troopsNumber = 0;
        troopsToRedeploy = 0;
        
    }
   
    public int playerNumber { get; set; }
    public int victoryPoint { get; set; }
    public PlayerPhase phase { get; set; }
    public Race actualRace { get; set; }
    public Power actualPower { get; set; }
    public Race decliningRace { get; set; }
    public List<int> conquestedCase { get; set; }
    public List<int> conquestedCaseDeclin { get; set; }
    public int troopsNumber { get; set; }
    public int troopsToRedeploy { get; set; }


    public bool doAction(Action act)
    {
        return phase.doAction(this, act);
    }
 

}
