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

    void Start()
    {
        GameManager.Instance.board.AddCase(CaseId, new BoardCase(adventage, adventage2, type, adjacenteCaseKeys, forgottenTribe, bord));
    }

    // Update is called once per frame
    void Update()
    {

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
        GameManager.Instance.refreshUis();
    }

}
