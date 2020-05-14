using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salamander : Race
{ 
    public Salamander()
    {
        name = "Salamandre";
        desc = "Une Mine occupée rapporte 1 jeton de victoire en fin de tour. Explosion instable, coûte 1 pt de victoire. 1/6 chance de conquérir le territoire sélectionné, même contesté.";
        imagePath = "Race/Salamandre_avis";
        phase = RacePhase.Actual;
        victoryPointAtPick = 0;
        troopsNumber = 3;
        troopsUsed = 0;
        troopsMax = 8;
        type = RaceType.Salamander; //Même comportement que le nain ... custom malgré tout ?
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
        int nitroToken = 0; //Ajout de la variable nitroToken qui correspond aux dynamites pouvant être consommée pour enclencher le pouvoir.
        foreach (int i in p.conquestedCase) //Pour toutes les cases conquises par le joueur.
        {
            if (GameManager.Instance.board.boardCases[i].adventage == BoardCase.CaseAdventage.Mine || GameManager.Instance.board.boardCases[i].adventage2 == BoardCase.CaseAdventage.Mine)
            //Si leurs avantages principaux où secondaires sont de types Mine alors ...
            {
                nitroToken++; //On ajoute une dynamite.
            }
        }
        return nitroToken; //Les dynamites obtenus sont convertis en point de victoires consommables.
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
