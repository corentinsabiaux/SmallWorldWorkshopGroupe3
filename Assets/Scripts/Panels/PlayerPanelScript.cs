using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelScript : MonoBehaviour
{
    public Text playerNumber;
    public Text victoryPoint;
    public Text raceName;
    public Text powerName;
    public Text phase;
    public Text troopsNumber;
    // Start is called before the first frame update
    void Start()
    {
        RefreshUi();
        GameManager.Instance.onUiChangeCallBack += RefreshUi;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RefreshUi()
    {

        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber-1];
        playerNumber.text = "Joueur : " + p.playerNumber;
        victoryPoint.text = "Point de victoire : " + p.victoryPoint;
        phase.text = p.phase.ToString();
        troopsNumber.text = "Nombre de troupes : " + p.troopsNumber;
        if (p.actualRace == null)
        {
            raceName.text = "Non choisie";
            powerName.text = "Non choisie";
        }
        else
        {
            raceName.text = p.actualRace.name;
            powerName.text = p.actualPower.name;
        }

    }
}
