using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectRaceAndPowerPhase : PlayerPhase
{
    public SelectRaceAndPowerPhase()
    {
        this.phaseName = "SelectRaceAndPowerPhase";
        GameManager.Instance.refreshUis();
    }
    public override bool doAction(Player player, Action act)
    {
        this.player = player;
        switch (act.type)
        {
            case Action.ActionType.DeckAction:
                return PickRaceAndPower(act.index);
                break;
            default:
                return false;
                break;
        }
    }
    public override void Enter(Player player)
    {

    }
    public override void Exit()
    {

    }

    public bool PickRaceAndPower(int deckShortListPosition)
    {
        switch (GameManager.Instance.gamePhase)
        {
            case GameManager.GamePhase.FirstTurn:
                if (player.victoryPoint >= deckShortListPosition)
                {
                    Race r;
                    Power p;
                    player.victoryPoint -= deckShortListPosition;
                    player.victoryPoint += GameManager.Instance.powerAndRaceDeck.racesShortList[deckShortListPosition].victoryPointAtPick;
                    GameManager.Instance.powerAndRaceDeck.PickRaceAndPower(deckShortListPosition, out r, out p);
                    player.actualRace = r;
                    player.actualPower = p;
                    player.troopsNumber = r.troopsNumber + p.troopsNumber;
                    this.Exit();
                    player.phase = new FirstConquestPhase();
                    player.phase.Enter(player);
                    switch (r.name)
                    {
                        case "Cactus":
                            GameObject cactus = GameObject.Instantiate(GameManager.Instance.playerFloat[0], GameManager.Instance.playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un cactus
                            cactus.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", GameManager.Instance.playerFloatAlbedo[0]);//applique a l'albedo la texture ayant le numéro du flottant
                            break;
                        case "Salamander":
                            GameObject tnt = GameObject.Instantiate(GameManager.Instance.playerFloat[1], GameManager.Instance.playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une TNT
                            tnt.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", GameManager.Instance.playerFloatAlbedo[1]);//applique a l'albedo la texture ayant le numéro du flottant
                            break;
                        case "Automate":
                            GameObject gourde = GameObject.Instantiate(GameManager.Instance.playerFloat[2], GameManager.Instance.playerFloatXYZ[GameManager.Instance.activePlayerNumber-1], Quaternion.identity); //instancie une gourde
                            gourde.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", GameManager.Instance.playerFloatAlbedo[2]);//applique a l'albedo la texture ayant le numéro du flottant
                            break;
                        case "Skeleton":
                            GameObject montre = GameObject.Instantiate(GameManager.Instance.playerFloat[3], GameManager.Instance.playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une montre
                            montre.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", GameManager.Instance.playerFloatAlbedo[2]);//applique a l'albedo la texture ayant le numéro du flottant
                            break;
                        default:
                            GameObject.Instantiate(GameManager.Instance.playerFloat[4], GameManager.Instance.playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un placeholder
                            break;
                    }
                    return true;
                }
                else
                {
                    Debug.Log("Pas asser de point de victroire");
                    return false;
                }
                break;
            case GameManager.GamePhase.ClassicTurn:
                if (player.victoryPoint >= deckShortListPosition)
                {
                    Race r;
                    Power p;
                    player.victoryPoint -= deckShortListPosition;
                    player.victoryPoint += GameManager.Instance.powerAndRaceDeck.racesShortList[deckShortListPosition].victoryPointAtPick;
                    GameManager.Instance.powerAndRaceDeck.PickRaceAndPower(deckShortListPosition, out r, out p);
                    player.actualRace = r;
                    player.actualPower = p;
                    player.troopsNumber = r.troopsNumber + p.troopsNumber;
                    player.phase = new FirstConquestPhase();
                    player.phase.Enter(player);
                    GameManager.Instance.refreshUis();
                    return true;
                }
                else
                {
                    Debug.Log("Pas asser de point de victroire");
                    return false;
                }
                return false;
                break;
            default:
                return false;
                break;
        }

        // test la valeur comprise entre 0 et 5 (choix 1 a 6)
        //valide la cout en point de victoire
        // affecte la race et le pouvoire

        //TO DO:separer en deux fonction 
    }

}

