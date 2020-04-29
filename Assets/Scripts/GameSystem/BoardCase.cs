using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCase
{
    public enum CaseType
    {
        Mountain,
        ForgottenTribe,
        Hills,
        Forest,
        Swamp,
        Fileds,
        water,
        Nothing
    }

    public enum CaseAdventage
    {
        Mine,
        MagicSource,
        Cave,
        Saloon,
        Nothing
    }


    public BoardCase(CaseAdventage adventage, CaseAdventage adventage2, CaseType type, List<int> adjacenteCaseKeys, int forgottenTribe, bool isBorder)
    {

        this.adventage = adventage;
        this.adventage2 = adventage2;
        this.type = type;
        this.adjacenteCaseKeys = new List<int>(adjacenteCaseKeys);
        troopsNumber = 0;
        this.forgottenTribe = forgottenTribe;
        this.haveFortresse = false;
        this.camping = 0;
        this.bord = isBorder;
        haveTrollLair = false;
        haveHero = false;
        haveDragon = false;
        haveSaloon = false;
        raceType = Race.RaceType.nothing;
        racePhase = Race.RacePhase.Actual;
        playerNumber = 0;
    }


    public CaseAdventage adventage { get; set; }
    public CaseAdventage adventage2 { get; set; }
    public CaseType type { get; set; }
    public List<int> adjacenteCaseKeys { get; set; }
    public bool bord { get; set; }
    public int troopsNumber { get; set; }
    public int forgottenTribe { get; set; }
    public int camping { get; set; }
    public bool haveFortresse { get; set; }
    public bool haveTrollLair { get; set; }
    public bool haveHero { get; set; }
    public bool haveDragon { get; set; }
    public bool haveSaloon { get; set; }
    public Race.RaceType raceType { get; set; }
    public int playerNumber {get;set;}
    public Race.RacePhase racePhase { get; set; }



}
