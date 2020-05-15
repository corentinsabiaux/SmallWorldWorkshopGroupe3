using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnselectAreaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer m = GetComponent<MeshRenderer>();
        if (GameManager.Instance.selectedCase >= 0)
        {
            m.enabled = true;
        } else
        {
            m.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.selectedCase >= 0)
        {
            GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1].doAction(new Action(Action.ActionType.UnselectAction, -1));
        }
    }
}
