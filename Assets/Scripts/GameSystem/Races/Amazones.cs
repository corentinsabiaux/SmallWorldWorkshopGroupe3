using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Amazones : Race
{
    public Amazones()
    {
        name = "Wendigo";
        desc = "Vous obtenez 4 troupes spéciales destinés à l'attaque uniquement. Si elles sont utilisées, elles sont remis dans votre main au début de votre tour et lors du redéploiement.";
        imagePath = "Race/Placeholder_avis";
        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 6;
        troopsUsed = 0;
        troopsMax = 15;
        type = RaceType.Amazones;
        specialTroops = 4;
    }

    public int specialTroops { get; set; }

    public override void StartTurn(Player p)
    {
        p.troopsNumber += specialTroops;
        specialTroops = 0;
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

        return 0;
    }

    public override void EndTurn(Player p)
    {
        //TO DO : gérer la récupération des troupes special, soit prendre au hasard 4 troupes dans les régions conquisent dans la limite du possible, soit ajouter un system d'event qui déclanche une fenetre de fonction special pour dire au joueur de slectionner 4 region ou on va retrire les troupe 
        specialTroops = p.troopsNumber >= 4 ? 4 : p.troopsNumber;
        p.troopsNumber -= specialTroops;
        if (specialTroops < 4)
        {
            foreach (int i in p.conquestedCase)
            {
                if (GameManager.Instance.board.boardCases[i].raceType == p.actualRace.type && specialTroops < 4)
                {
                    if (GameManager.Instance.board.boardCases[i].troopsNumber >= 2)
                    {
                        GameManager.Instance.board.boardCases[i].troopsNumber--;
                        specialTroops++;
                    }
                }
            }
        }
    }

    public override void LoosConquestedCase(int boardPos, Player p) { }

    public override void Declin(Player p)
    {
        phase = RacePhase.Declin;
    }
}
