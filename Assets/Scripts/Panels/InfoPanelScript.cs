using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InfoPanelScript : MonoBehaviour
{
    public Text info;
    public Button unselectButton;
    public Button lastConquestButton;
    public Button dcliningButton;
    public Button startConquest;
    public Button endOfplayerTurn;
    public Button skeletonButton; //Ajout de la référence du skeletonButton présent dans la scène Unity.
    public Button salamanderButton; //Ajout de la référence du salamanderButton présent dans la scène Unity.
    public InputField numberInput;
    // Start is called before the first frame update
    void Start()
    {
        RefreshUi();
        GameManager.Instance.onUiChangeCallBack += RefreshUi;
        unselectButton.onClick.AddListener(Unselect);
        lastConquestButton.onClick.AddListener(LastConquest);
        endOfplayerTurn.onClick.AddListener(PlayerTurnEnd);
        dcliningButton.onClick.AddListener(Declining);
        startConquest.onClick.AddListener(starConquest);
        skeletonButton.onClick.AddListener(skeletonToken); //Ajout du script dans le bouton présent dans la scène Unity pour déclencher l'action de la race Squelette.
        salamanderButton.onClick.AddListener(salamanderToken); //Ajout du script dans le bouton présent dans la scène Unity pour déclencher l'action de la race Salamander.
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void RefreshUi()
    {
        //Ajout de la référence du script player pour obtenir le joueur actuel.
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];
        if (GameManager.Instance.selectedCase == -1)
        {
            info.text = "Aucune case selectionné ";
            unselectButton.interactable = false;
            numberInput.interactable = false;
        }
        else
        {
            BoardCase b = GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase];
            info.text = "Casse numero : " + GameManager.Instance.selectedCase + " c'est une " +
            b.type + "\n"
            + "Peuple oublié :" + b.forgottenTribe + "\n"
            + "Troupe deployer " + b.troopsNumber + "\n"
            + "Occupé par le joueur :  " + b.playerNumber
            + " posséde un.e" + b.adventage + " et un.e" + b.adventage2;
            unselectButton.interactable = true;
            if (numberInput.interactable)
            {
                GameManager.Instance.selectedNumber = numberInput.text == "" ? -1 : Int32.Parse(numberInput.text);
            }
            if (p.phase.phaseName == "EndOfTurnPhase" || p.phase.phaseName == "LoosConquestedCasePhase")
            {
                numberInput.interactable = true;
            }
            else
            {
                numberInput.interactable = false;
            }
        }

        lastConquestButton.interactable = false;
        endOfplayerTurn.interactable = true;
        startConquest.interactable = false;
        dcliningButton.interactable = false;
        //Par sécurité, on met en false la possibilité d'appuyer sur le bouton dans tous les cas.
        skeletonButton.interactable = false;
        if (p.phase.phaseName == "FirstConquestPhase" && p.actualRace.name == "Skeleton" || p.phase.phaseName == "ConquestPhase" && p.actualRace.name == "Skeleton" || p.phase.phaseName == "LastConquestPhase" && p.actualRace.name == "Skeleton")
        //Si on est dans toutes les phases de Conquête alors ...
        {
            skeletonButton.interactable = true;
            //Le bouton de déclenchement de l'action de la race Squelette peut-être cliqué.
        }
        //Par sécurité, on met en false la possibilité d'appuyer sur le bouton dans tous les cas.
        salamanderButton.interactable = false;
        if (p.phase.phaseName == "LastConquestPhase" && p.actualRace.name == "Salamander" && GameManager.Instance.selectedCase > 0 && GameManager.Instance.selectedCase < 40 && p.victoryPoint > 0)
        //Si on est dans la phase 'Dernière conquête' alors ...
        {
            salamanderButton.interactable = true;
            //Le bouton de déclenchement de l'action de la race Salamander peut-être cliqué.
        }

        switch (p.phase.phaseName)
        {
            case "ConquestPhase":
                lastConquestButton.interactable = true;
                break;
            case "StartOfTurnPhase":
                startConquest.interactable = true;
                dcliningButton.interactable = true;
                endOfplayerTurn.interactable = false;
                break;
            default:
                break;
        }

    }

    public void Unselect()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.UnselectAction, -1));
        numberInput.text = "";
    }

    public void LastConquest()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.LastConquestAction, -1));
    }

    public void PlayerTurnEnd()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.EndOfTurnAction, -1));
    }

    public void Declining()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.DeclinAction, -1));
    }

    public void starConquest()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.StartConquestAction, -1));
    }
    //Ajout du déclenchement de l'action de race Squelette.
    public void skeletonToken()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.SkeletonAction, -1));
    }
    //Ajout du déclenchement de l'action de race Salamander.
    public void salamanderToken()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.SalamanderAction, -1));
    }
}
