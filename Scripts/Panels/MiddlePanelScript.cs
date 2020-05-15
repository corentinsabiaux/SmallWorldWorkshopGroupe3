using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MiddlePanelScript : MonoBehaviour
{
    public GameObject MiddlePanel;
    public GameObject UnteractableMap;
    public Text textUp;
    public Text playerNumber;
    public Text textMiddle;
    public Text textArrow;
    public Button buttonConquest;
    public Button buttonDeclining;
    public Text textConquest;
    public Text textDeclining;
    public Button buttonRaceAndPower;
    public Text textRaceAndPowerName;
    public Text textRaceAndPowerDesc;
    public Text textCaseName;
    public Text textCaseDesc;
    public GameObject numberInputGO;
    public InputField numberInput;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
        GameManager.Instance.onUiChangeCallBack += RefreshUI;
        buttonConquest.onClick.AddListener(starConquest);
        buttonDeclining.onClick.AddListener(Declining);
        buttonRaceAndPower.onClick.AddListener(CloseMiddlePlanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshUI()
    {
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];

        playerNumber.text = "Joueur " + p.playerNumber;

        if (p.phase.phaseName == "SelectRaceAndPowerPhase")
        {
            MiddlePanel.SetActive(true);
            UnteractableMap.SetActive(true);
            GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = false;
            GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = false;
            numberInputGO.SetActive(false);
            textConquest.enabled = false;
            textDeclining.enabled = false;
            buttonConquest.enabled = false;
            buttonDeclining.enabled = false;
            buttonConquest.image.enabled = false;
            buttonDeclining.image.enabled = false;
            textRaceAndPowerName.enabled = false;
            textRaceAndPowerDesc.enabled = false;
            buttonRaceAndPower.enabled = false;
            buttonRaceAndPower.image.enabled = false;
            textCaseName.enabled = false;
            textCaseDesc.enabled = false;
            textUp.text = "Bienvenue !";
            textMiddle.text = "Piochez une tuile ...";
            textUp.enabled = true;
            playerNumber.enabled = true;
            textMiddle.enabled = true;
            textArrow.enabled = true;
        } else if (p.phase.phaseName == "StartOfTurnPhase")
        {
            MiddlePanel.SetActive(true);
            UnteractableMap.SetActive(true);
            GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = false;
            GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = false;
            numberInputGO.SetActive(false);
            textMiddle.enabled = false;
            textArrow.enabled = false;
            textRaceAndPowerName.enabled = false;
            textRaceAndPowerDesc.enabled = false;
            buttonRaceAndPower.enabled = false;
            buttonRaceAndPower.image.enabled = false;
            textCaseName.enabled = false;
            textCaseDesc.enabled = false;
            textUp.text = "C'est votre tour !";
            textUp.enabled = true;
            playerNumber.enabled = true;
            textConquest.enabled = true;
            textDeclining.enabled = true;
            buttonConquest.enabled = true;
            buttonDeclining.enabled = true;
            buttonConquest.image.enabled = true;
            buttonDeclining.image.enabled = true;
        } else
        {
            CloseMiddlePlanel();
        }

        switch (GameManager.Instance.activePlayerNumber - 1)
        {
            case 0:
                Color blueToken = new Color(0.121f, 0f, 0.411f, 1f);
                playerNumber.color = blueToken;
                textArrow.color = blueToken;
                textConquest.color = blueToken;
                textDeclining.color = blueToken;
                textRaceAndPowerName.color = blueToken;
                textCaseName.color = blueToken;
                break;
            case 1:
                Color greenToken = new Color(0f, 0.364f, 0.117f, 1f);
                playerNumber.color = greenToken;
                textArrow.color = greenToken;
                textConquest.color = greenToken;
                textDeclining.color = greenToken;
                textRaceAndPowerName.color = greenToken;
                textCaseName.color = greenToken;
                break;
            case 2:
                Color redToken = new Color(0.741f, 0f, 0f, 1f);
                playerNumber.color = redToken;
                textArrow.color = redToken;
                textConquest.color = redToken;
                textDeclining.color = redToken;
                textRaceAndPowerName.color = redToken;
                textCaseName.color = redToken;
                break;
            case 3:
                Color yellowToken = new Color(0.576f, 0.568f, 0f, 1f);
                playerNumber.color = yellowToken;
                textArrow.color = yellowToken;
                textConquest.color = yellowToken;
                textDeclining.color = yellowToken;
                textRaceAndPowerName.color = yellowToken;
                textCaseName.color = yellowToken;
                break;
        }
    }

    public void Declining()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.DeclinAction, -1));
    }

    public void starConquest()
    {
        GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.StartConquestAction, -1));
    }

    public void RaceInfoOn()
    {
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];

        MiddlePanel.SetActive(true);
        UnteractableMap.SetActive(true);
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.image.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualPower.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualPower.image.enabled = false;
        numberInputGO.SetActive(false);
        textUp.enabled = false;
        playerNumber.enabled = false;
        textMiddle.enabled = false;
        textArrow.enabled = false;
        textConquest.enabled = false;
        textDeclining.enabled = false;
        buttonConquest.enabled = false;
        buttonDeclining.enabled = false;
        buttonConquest.image.enabled = false;
        buttonDeclining.image.enabled = false;
        textCaseName.enabled = false;
        textCaseDesc.enabled = false;
        buttonRaceAndPower.image.sprite = Resources.Load<Sprite>(p.actualRace.imagePath);
        textRaceAndPowerName.text = p.actualRace.name;
        textRaceAndPowerDesc.text = p.actualRace.desc;
        textRaceAndPowerName.enabled = true;
        textRaceAndPowerDesc.enabled = true;
        buttonRaceAndPower.enabled = true;
        buttonRaceAndPower.image.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualRace.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualRace.image.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.image.enabled = true;
    }

    public void PowerInfoOn()
    {
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];

        MiddlePanel.SetActive(true);
        UnteractableMap.SetActive(true);
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualRace.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualRace.image.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.image.enabled = false;
        numberInputGO.SetActive(false);
        textUp.enabled = false;
        playerNumber.enabled = false;
        textMiddle.enabled = false;
        textArrow.enabled = false;
        textConquest.enabled = false;
        textDeclining.enabled = false;
        buttonConquest.enabled = false;
        buttonDeclining.enabled = false;
        buttonConquest.image.enabled = false;
        buttonDeclining.image.enabled = false;
        textCaseName.enabled = false;
        textCaseDesc.enabled = false;
        buttonRaceAndPower.image.sprite = Resources.Load<Sprite>(p.actualPower.imagePath);
        textRaceAndPowerName.text = p.actualPower.name;
        textRaceAndPowerDesc.text = p.actualPower.desc;
        textRaceAndPowerName.enabled = true;
        textRaceAndPowerDesc.enabled = true;
        buttonRaceAndPower.enabled = true;
        buttonRaceAndPower.image.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualPower.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualPower.image.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.image.enabled = true;
    }

    public void CaseInfoOn()
    {
        MiddlePanel.SetActive(true);
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = false;
        numberInputGO.SetActive(false);
        textUp.enabled = false;
        playerNumber.enabled = false;
        textMiddle.enabled = false;
        textArrow.enabled = false;
        textConquest.enabled = false;
        textDeclining.enabled = false;
        buttonConquest.enabled = false;
        buttonDeclining.enabled = false;
        buttonConquest.image.enabled = false;
        buttonDeclining.image.enabled = false;
        buttonRaceAndPower.enabled = false;
        buttonRaceAndPower.image.enabled = false;
        textRaceAndPowerName.enabled = false;
        textRaceAndPowerDesc.enabled = false;
        textCaseName.enabled = true;
        textCaseDesc.enabled = true;
        BoardCase b = GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase];
        textCaseName.text = "Case " + b.type;
        textCaseDesc.text = "Cliquez sur la carte = Confirmer choix" + "\n" +"Cliquez sur la zone jaune = Annuler" + "\n" + "\n"+ "Peuple oublié : " 
        + b.forgottenTribe + "\n"
        + "Troupe déployée : " + b.troopsNumber + "\n"
        + "Occupé par le joueur " + b.playerNumber
        + " possède un.e " + b.adventage + " et un.e " + b.adventage2;
    }

    public void CloseMiddlePlanel()
    {
        MiddlePanel.SetActive(false);
        UnteractableMap.SetActive(false);
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualRace.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualRace.image.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualPower.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().buttonCloseMiddlePanelByActualPower.image.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.image.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = true;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.image.enabled = true;
    }

    public void LoosConquestedInfoOn()
    {
        MiddlePanel.SetActive(true);
        numberInputGO.SetActive(true);
        UnteractableMap.SetActive(true);
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().raceButton.enabled = false;
        GameObject.Find("PanelsScripts").GetComponent<PlayerPanelScript>().powerButton.enabled = false;
        textUp.enabled = false;
        playerNumber.enabled = false;
        textMiddle.enabled = false;
        textArrow.enabled = false;
        textConquest.enabled = false;
        textDeclining.enabled = false;
        buttonConquest.enabled = false;
        buttonDeclining.enabled = false;
        buttonConquest.image.enabled = false;
        buttonDeclining.image.enabled = false;
        buttonRaceAndPower.enabled = false;
        buttonRaceAndPower.image.enabled = false;
        textRaceAndPowerName.enabled = false;
        textRaceAndPowerDesc.enabled = false;
        textCaseName.enabled = true;
        textCaseDesc.enabled = true;
        BoardCase b = GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase];
        textCaseName.text = "Redéploiement";
        textCaseDesc.text = "\n" + "\n" + "Combien d'unités souhaitez-vous redéployer sur cette case ?" + "\n" + b.troopsNumber + " restant.s.";
        GameManager.Instance.selectedNumber = numberInput.text == "" ? -1 : Int32.Parse(numberInput.text);
    }
}
