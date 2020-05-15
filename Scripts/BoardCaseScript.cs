using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCaseScript : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float decalageX;
    [Range(-1f, 1f)]
    public float decalageZ;
    public int CaseId;
    public BoardCase.CaseAdventage adventage;
    public BoardCase.CaseAdventage adventage2;
    public BoardCase.CaseType type;
    public List<int> adjacenteCaseKeys;
    public bool bord;
    public int forgottenTribe;
    private Color startColor;

    void Start()
    {
        GameManager.Instance.board.AddCase(CaseId, new BoardCase(adventage, adventage2, type, adjacenteCaseKeys, forgottenTribe, bord));
        startColor = GetComponent<MeshRenderer>().material.color;
        GameManager.Instance.onUiChangeCallBack += RefreshUI;
    }

    // Update is called once per frame
    void Update()
    {
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];
        if (GameManager.Instance.selectedCase == CaseId)
        {
            GameObject.Find("PanelsScripts").GetComponent<MiddlePanelScript>().CaseInfoOn();
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = startColor;
        }
        //Si on est dans la phase 'Dernière conquête' alors ...
        if (p.phase.phaseName == "LastConquestPhase" && p.actualRace.name == "Salamandre" && p.victoryPoint > 0 && GameManager.Instance.selectedCase == CaseId)
        {
            GameObject.Find("PanelsScripts").GetComponent<InfoPanelScript>().SalamanderButtonOn();
        }

        if (p.phase.phaseName == "EndOfTurnPhase" && GameManager.Instance.selectedCase == CaseId || p.phase.phaseName == "LoosConquestedCasePhase" && GameManager.Instance.selectedCase == CaseId)
        {
            GameObject.Find("PanelsScripts").GetComponent<MiddlePanelScript>().LoosConquestedInfoOn();
        }
    }
    void OnMouseDown()
    {
        if (GameManager.Instance.players[GameManager.Instance.activePlayerNumber-1].doAction(new Action(Action.ActionType.MapAction,CaseId,GameManager.Instance.selectedNumber)))
        {
        }
        else
        {
            Debug.Log("selection impossible");
        }
    }
    public void RefreshUI()
    { if (GameManager.Instance.selectedCase == CaseId)
        {
            clearCase();
            BoardCase b = GameManager.Instance.board.boardCases[CaseId];
            for (int i = 0; i < b.troopsNumber; i++)
            {
                GameObject t = GameObject.Instantiate(GameManager.Instance.token, gameObject.transform); //instancie un jeton
                t.transform.position = GameObject.Find(CaseId.ToString()).transform.position; //alors la position du jeton est egale a la position de la case
                t.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", GameManager.Instance.albedo[b.playerNumber - 1]);//applique a l'albedo la texture ayant le numéro du joueur dans la liste de texture (GameManager)
                t.transform.eulerAngles = new Vector3(t.transform.rotation.x, UnityEngine.Random.Range(0f, 360f), t.transform.rotation.z);// donne une rotation aléatoire sur y au jeton

                if (i > 0)
                {
                    t.transform.position = new Vector3(t.transform.position.x + 0f, t.transform.position.y + i * 0.05f, t.transform.position.z + 0f);//superpose les jetons
                    t.transform.position = new Vector3(t.transform.position.x + UnityEngine.Random.Range(-0.1f, 0.1f), t.transform.position.y, t.transform.position.z + UnityEngine.Random.Range(-0.1f, 0.1f));// donne des random position au jeton pour donner un effet plus realiste

                }
                t.transform.position = t.transform.position + new Vector3(decalageX, 0, decalageZ);
            }
        }
    }
    public void clearCase()
    {

        if (this.transform.childCount > 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }
    }
}
