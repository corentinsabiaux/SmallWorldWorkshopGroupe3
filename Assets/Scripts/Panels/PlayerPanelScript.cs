using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerPanelScript : MonoBehaviour
{
    public Text playerNumber;
    public Text victoryPoint;
    public Text raceName;
    public Text powerName;
    public Button raceButton;
    public Button powerButton;
    public Button buttonCloseMiddlePanelByActualRace;
    public Button buttonCloseMiddlePanelByActualPower;
    public Image troopsNumberImage;
    public Text phase;
    public Text troopsNumber;
    // Start is called before the first frame update
    void Start()
    {
        RefreshUi();
        GameManager.Instance.onUiChangeCallBack += RefreshUi;
        raceButton.onClick.AddListener(GameObject.Find("PanelsScripts").GetComponent<MiddlePanelScript>().RaceInfoOn);
        powerButton.onClick.AddListener(GameObject.Find("PanelsScripts").GetComponent<MiddlePanelScript>().PowerInfoOn);
        buttonCloseMiddlePanelByActualRace.onClick.AddListener(GameObject.Find("PanelsScripts").GetComponent<MiddlePanelScript>().CloseMiddlePlanel);
        buttonCloseMiddlePanelByActualPower.onClick.AddListener(GameObject.Find("PanelsScripts").GetComponent<MiddlePanelScript>().CloseMiddlePlanel);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void RefreshUi()
    {
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];
        playerNumber.text = "Joueur " + p.playerNumber;

        troopsNumber.text = p.troopsNumber + "";
        if (p.actualRace == null)
        {
            raceName.text = "Non choisie";
            powerName.text = "Non choisie";

            raceButton.enabled = false;
            powerButton.enabled = false;
            raceButton.image.sprite = null;
            powerButton.image.sprite = null;
            raceButton.image.enabled = false;
            powerButton.image.enabled = false;
        }
        else
        {
            raceName.text = p.actualRace.name;
            powerName.text = p.actualPower.name;

            raceButton.enabled = true;
            powerButton.enabled = true;
            raceButton.image.sprite = Resources.Load<Sprite>(p.actualRace.imagePath);
            powerButton.image.sprite = Resources.Load<Sprite>(p.actualPower.imagePath);
            buttonCloseMiddlePanelByActualRace.image.sprite = Resources.Load<Sprite>(p.actualRace.imagePath);
            buttonCloseMiddlePanelByActualPower.image.sprite = Resources.Load<Sprite>(p.actualPower.imagePath);
            raceButton.image.enabled = true;
            powerButton.image.enabled = true;
        }
        
        switch (GameManager.Instance.activePlayerNumber - 1)
        {
            case 0:
                Color blueToken = new Color(0.121f, 0f, 0.411f, 1f);
                playerNumber.color = blueToken;
                raceName.color = blueToken;
                powerName.color = blueToken;
                troopsNumber.color = blueToken;
                troopsNumberImage.sprite = Resources.Load<Sprite>("UI/Jetons/Tokens_J1");
                break;
            case 1:
                Color greenToken = new Color(0f, 0.364f, 0.117f, 1f);
                playerNumber.color = greenToken;
                raceName.color = greenToken;
                powerName.color = greenToken;
                troopsNumber.color = greenToken;
                troopsNumberImage.sprite = Resources.Load<Sprite>("UI/Jetons/Tokens_J2");
                break;
            case 2:
                Color redToken = new Color(0.741f, 0f, 0f, 1f);
                playerNumber.color = redToken;
                raceName.color = redToken;
                powerName.color = redToken;
                troopsNumber.color = redToken;
                troopsNumberImage.sprite = Resources.Load<Sprite>("UI/Jetons/Tokens_J3");
                break;
            case 3:
                Color yellowToken = new Color(0.576f, 0.568f, 0f, 1f);
                playerNumber.color = yellowToken;
                raceName.color = yellowToken;
                powerName.color = yellowToken;
                troopsNumber.color = yellowToken;
                troopsNumberImage.sprite = Resources.Load<Sprite>("UI/Jetons/Tokens_J4");
                break;
        }
    }
}
