using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckPanelScript : MonoBehaviour
{
    public VerticalLayoutGroup listContent;
    public GameObject RaceAndPowerPrefab;

    public GameObject DeckPanel;
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
            DeckPanel.SetActive(false);
        }
        else
        {
            DeckCachePanel.SetActive(false);
            DeckPanel.SetActive(true);
        }
        clearVerticalLayout();
        int i = 0;
        foreach (Race r in GameManager.Instance.powerAndRaceDeck.racesShortList)
        {
            int ia = i;
            GameObject go = Instantiate(RaceAndPowerPrefab, listContent.transform);
            Text[] texts = go.GetComponentsInChildren<Text>();
            texts[0].text = r.name;
            texts[0].transform.position = new Vector3(texts[0].transform.position.x + 10, texts[0].transform.position.y - 110, texts[0].transform.position.z);
            texts[0].fontSize = 15;
            texts[0].font = Resources.Load<Font>("Fonts/zTextMesh Pro/Fonts/LiberationSans");
            texts[0].fontStyle = FontStyle.Bold;
            texts[1].text = GameManager.Instance.powerAndRaceDeck.powersShortList[i].name;
            texts[1].transform.position = new Vector3(texts[1].transform.position.x, texts[1].transform.position.y - 110, texts[1].transform.position.z);
            texts[1].fontSize = 15;
            texts[1].font = Resources.Load<Font>("Fonts/zTextMesh Pro/Fonts/LiberationSans");
            texts[1].fontStyle = FontStyle.Bold;
            Image[] images = go.GetComponentsInChildren<Image>();
            images[0].sprite = Resources.Load<Sprite>(r.imagePath);
            images[1].sprite = Resources.Load<Sprite>(GameManager.Instance.powerAndRaceDeck.powersShortList[i].imagePath);
            images[1].transform.position = new Vector3(images[1].transform.position.x - 20, images[1].transform.position.y, images[1].transform.position.z);
            switch (GameManager.Instance.activePlayerNumber - 1)
            {
                case 0:
                    Color blueToken = new Color(0.121f, 0f, 0.411f, 1f);
                    texts[0].color = blueToken;
                    texts[1].color = blueToken;
                    break;
                case 1:
                    Color greenToken = new Color(0f, 0.364f, 0.117f, 1f);
                    texts[0].color = greenToken;
                    texts[1].color = greenToken;
                    break;
                case 2:
                    Color redToken = new Color(0.741f, 0f, 0f, 1f);
                    texts[0].color = redToken;
                    texts[1].color = redToken;
                    break;
                case 3:
                    Color yellowToken = new Color(0.576f, 0.568f, 0f, 1f);
                    texts[0].color = yellowToken;
                    texts[1].color = yellowToken;
                    break;
            }
            go.GetComponentInChildren<Button>().onClick.AddListener(() => { PickRaceAndPower(ia); });
            i++;
        }


    }

    public void PickRaceAndPower(int index)
    {
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
