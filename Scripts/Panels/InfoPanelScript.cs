using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InfoPanelScript : MonoBehaviour
{
    public Button lastConquestButton;
    public Button endOfplayerTurn;
    public Button skeletonButton; //Ajout de la référence du skeletonButton présent dans la scène Unity.
    public Button salamanderButton; //Ajout de la référence du salamanderButton présent dans la scène Unity.

    // Start is called before the first frame update
    void Start()
    {
        RefreshUi();
        GameManager.Instance.onUiChangeCallBack += RefreshUi;
        lastConquestButton.onClick.AddListener(LastConquest);
        endOfplayerTurn.onClick.AddListener(PlayerTurnEnd);
        skeletonButton.onClick.AddListener(SkeletonToken); //Ajout du script dans le bouton présent dans la scène Unity pour déclencher l'action de la race Squelette.
        salamanderButton.onClick.AddListener(SalamanderToken); //Ajout du script dans le bouton présent dans la scène Unity pour déclencher l'action de la race Salamander.
    }

    public void RefreshUi()
    {
        //Ajout de la référence du script player pour obtenir le joueur actuel.
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];

        lastConquestButton.enabled = false;
        lastConquestButton.image.enabled = false;
        endOfplayerTurn.interactable = true;
        //Par sécurité, on met en false la possibilité d'appuyer sur le bouton dans tous les cas.
        skeletonButton.enabled = false;
        skeletonButton.image.enabled = false;
        if (p.phase.phaseName == "FirstConquestPhase" && p.actualRace.name == "Squelette" && p.victoryPoint > 0 && p.troopsNumber < p.actualRace.troopsMax || p.phase.phaseName == "ConquestPhase" && p.actualRace.name == "Squelette" && p.victoryPoint > 0 && p.troopsNumber < p.actualRace.troopsMax || p.phase.phaseName == "LastConquestPhase" && p.actualRace.name == "Squelette" && p.victoryPoint > 0 && p.troopsNumber < p.actualRace.troopsMax)
        //Si on est dans toutes les phases de Conquête alors ...
        {
            skeletonButton.enabled = true;
            skeletonButton.image.enabled = true;
            //Le bouton de déclenchement de l'action de la race Squelette peut-être cliqué.
        }
        //Par sécurité, on met en false la possibilité d'appuyer sur le bouton dans tous les cas.
        salamanderButton.enabled = false;
        salamanderButton.image.enabled = false;

        switch (p.phase.phaseName)
        {
            case "ConquestPhase":
                lastConquestButton.enabled = true;
                lastConquestButton.image.enabled = true;
                break;
            case "StartOfTurnPhase":
                endOfplayerTurn.interactable = false;
                break;
            default:
                break;
        }

    }

    public void LastConquest()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.LastConquestAction, -1));
    }

    public void PlayerTurnEnd()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.EndOfTurnAction, -1));
    }

    //Ajout du déclenchement de l'action de race Squelette.
    public void SkeletonToken()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.SkeletonAction, -1));
    }
    //Ajout du déclenchement de l'action de race Salamander.
    public void SalamanderToken()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.SalamanderAction, -1));
    }

    public void SalamanderButtonOn()
    {
        salamanderButton.enabled = true;
        salamanderButton.image.enabled = true;
        //Le bouton de déclenchement de l'action de la race Salamander peut-être cliqué.
    }
}
