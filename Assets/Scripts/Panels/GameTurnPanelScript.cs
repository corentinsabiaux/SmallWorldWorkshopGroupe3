using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTurnPanelScript : MonoBehaviour
{
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;
    public Image img6;
    public Image img7;
    public Image img8;
    public Image img9;
    public Image img10;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUi();
        GameManager.Instance.onNextTurnCallback += RefreshUi;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RefreshUi()
    {
        img1.enabled  = false;
        img2.enabled  = false;
        img3.enabled  = false;
        img4.enabled  = false;
        img5.enabled  = false;
        img6.enabled  = false;
        img7.enabled  = false;
        img8.enabled  = false;
        img9.enabled  = false;
        img10.enabled  = false;

        switch (GameManager.Instance.gameTurn)
        {
            case 1:
                img1.enabled  = true;
                break;
            case 2:
                img2.enabled  = true;
                break;
            case 3:
                img3.enabled  = true;
                break;
            case 4:
                img4.enabled  = true;
                break;
            case 5:
                img5.enabled  = true;
                break;
            case 6:
                img6.enabled  = true;
                break;
            case 7:
                img7.enabled  = true;
                break;
            case 8:
                img8.enabled  = true;
                break;
            case 9:
                img9.enabled  = true;
                break;
            case 10:
                img10.enabled  = true;
                break;

            default:
            break;
        }


    }
}
