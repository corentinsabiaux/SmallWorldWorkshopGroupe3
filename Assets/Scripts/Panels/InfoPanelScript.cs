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
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RefreshUi()
    {
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
            if (p.phase.phaseName == "EndOfTurnPhase" || p.phase.phaseName == "LoosConquestedCasePhase" )
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
}
