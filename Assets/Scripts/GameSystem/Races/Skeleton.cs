using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Race
{
    //La race Squelette est implémenté, son pouvoir est visible en action dans les scripts FirstConquestPhase / ConquestPhase / LastConquestPhase.
    public Skeleton()
    {
        name = "Skeleton";
        desc = "Vous pouvez utiliser des points de victoires comme des pions, pour la conquête uniquement.";
        imagePath = "Race/Squelettes_avis";
        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 8;
        troopsUsed = 0;
        troopsMax = 13;
        type = RaceType.Skeleton;
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
        return 0;
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
