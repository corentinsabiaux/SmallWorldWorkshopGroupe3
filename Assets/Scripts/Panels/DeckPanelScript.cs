using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckPanelScript : MonoBehaviour
{
    public VerticalLayoutGroup listContent;
    public GameObject RaceAndPowerPrefab;

    public GameObject DeckCachePanel;

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
        if (!(GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].phase.phaseName == "SelectRaceAndPowerPhase"))
        {
            DeckCachePanel.SetActive(true);
        }
        else
        {
            DeckCachePanel.SetActive(false);
        }
        clearVerticalLayout();
        int i = 0;
        foreach (Race r in GameManager.Instance.powerAndRaceDeck.racesShortList)
        {
            int ia = i;
            GameObject go = Instantiate(RaceAndPowerPrefab, listContent.transform);
            Text[] texts = go.GetComponentsInChildren<Text>();
            texts[0].text = r.name;
            texts[1].text = GameManager.Instance.powerAndRaceDeck.powersShortList[i].name;
            Image[] images = go.GetComponentsInChildren<Image>();

            images[0].sprite = Resources.Load<Sprite>(r.imagePath);
            images[1].sprite = Resources.Load<Sprite>(GameManager.Instance.powerAndRaceDeck.powersShortList[i].imagePath);
            go.GetComponentInChildren<Button>().onClick.AddListener(() => { PickRaceAndPower(ia); });
            i++;
        }


    }

    public void PickRaceAndPower(int index)
    {

        /* switch (p.phase)
         {
             case Player.PlayerPhases.SelectRaceAndPower:
                 if (p.PickRaceAndPower(index))
                 {
                     clearVerticalLayout();
                     RefreshUi();
                     if (GameManager.Instance.gamePhase == GameManager.GamePhase.FirstTurn)
                     {
                         if (GameManager.Instance.activePlayerNumber == GameManager.Instance.players.Count)
                         {
                            p.phase = Player.PlayerPhases.FirstConquest;
                         }
                         GameManager.Instance.NextPlayer();
                     }
                 }
                 else
                 {
                     Debug.Log("Pas asser de point de victroire");
                 }
                 break;
             case Player.PlayerPhases.declining :
             case Player.PlayerPhases.FirstConquest :
             case Player.PlayerPhases.Conquest :
             case Player.PlayerPhases.LastConquestAction :
             case Player.PlayerPhases.EndOfTurn :
             default:
             break; */


        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];
        if (p.doAction(new Action(Action.ActionType.DeckAction, index)))
        {
            clearVerticalLayout();
            RefreshUi();
        }


    }

    public void clearVerticalLayout()
    {

        if (listContent.transform.childCount > 0)
        {
            for (int i = 0; i < listContent.transform.childCount; i++)
            {
                Destroy(listContent.transform.GetChild(i).gameObject);
            }
        }
    }
}
