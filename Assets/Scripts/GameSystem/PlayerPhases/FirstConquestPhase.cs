using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
public class FirstConquestPhase : PlayerPhase
{
    public FirstConquestPhase()
    {
        this.phaseName = "FirstConquestPhase";
        GameManager.Instance.selectedCase = -1;
        GameManager.Instance.refreshUis();
    }
    public override bool doAction(Player player, Action act)
    {
        //Ajout de la référence du script player pour obtenir le joueur actuel.
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];
        switch (act.type)
        {
            case Action.ActionType.MapAction:
                if (GameManager.Instance.selectedCase == -1)
                {
                    return CanConquest(act.index);
                }
                if (GameManager.Instance.selectedCase > 0 && GameManager.Instance.selectedCase < 40)
                {
                    return Conquest(GameManager.Instance.selectedCase);
                }
                return false;
                break;
            case Action.ActionType.UnselectAction:
                GameManager.Instance.selectedCase = -1;
                GameManager.Instance.refreshUis();
                return true;
                break;

            case Action.ActionType.SkeletonAction: //Ajout de l'action de la faction Squelette.
                if (p.victoryPoint > 0 && p.troopsNumber < p.actualRace.troopsMax) //Si les points de victoire du joueur actuel sont > 0 et que le nombre de troupes qu'il possède est inférieur au nombre de troupe pouvant être instancié alors ... 
                {
                    //On convertit 1 point de victoire en 1 unité.
                    p.victoryPoint -= 1;
                    p.troopsNumber += 1;
                    GameManager.Instance.refreshUis(); //On rafraîchit l'UI pour que la conversion soit visible au joueur.
                }
                else
                {
                    Debug.LogError("Conversion impossible, victoryPoint < 1 && p.troopsNumber < p.actualRace.troopsMax"); //Concerne que le debug, sera supprimé en master.

                }
                return true;
                break;

            case Action.ActionType.SalamanderAction: //Ajout de l'action de la faction Salamandre.
                int rollResult = GameManager.Instance.RollTheDice(); //On lance un dé dont le résultat va être stocké localement dans la variable int rollResult.
                if (rollResult == 0) //Si le résultat est 0, on entre en état d'échec.
                {
                    p.victoryPoint -= 1; //Le joueur consomme un point de victoire pour l'utilisation du pouvoir.
                    GameManager.Instance.NextPlayer(); //Le joueur perd son tour de jeu.
                }

                if (rollResult == 1 || rollResult == 2) //Si le résultat est compris entre 1 & 2, on entre en état neutre.
                {
                    p.victoryPoint -= 1; //Le joueur consomme un point de victoire pour l'utilisation du pouvoir.
                }

                if (rollResult == 3) //Si le résultat est 3, on entre en état d'échec.
                {
                    return Conquest(GameManager.Instance.selectedCase); //Le joueur place une unité et conquit le territoire.
                }
                GameManager.Instance.refreshUis(); //On rafraîchit l'UI pour que le tout soit visible au joueur.
                return true;
                break;
            default:
                return false;
                break;
        }
    }
    public override void Enter(Player player)
    {
        this.player = player;
        this.StartTurn();
    }
    public override void Exit()
    {
        player.phase = new ConquestPhase();
        player.phase.Enter(player);
    }

    public void StartTurn()
    {
        player.actualRace.StartTurn(player);
    }

    public bool CanConquest(int boardPos)
    {
        if (GameManager.Instance.board.boardCases[boardPos].type == BoardCase.CaseType.water)
        {
            return false;
        }
        if (GameManager.Instance.board.boardCases[boardPos].haveDragon || GameManager.Instance.board.boardCases[boardPos].haveHero)
        {
            return false;
        }
        if (GameManager.Instance.board.boardCases[boardPos].bord)
        {
            if (ConquestCost(boardPos) <= player.troopsNumber)
            {
                GameManager.Instance.selectedCase = boardPos;
                return true;
            }
        }
        if (player.actualPower.CanConquest(boardPos,player) || player.actualRace.CanConquest(boardPos,player))
        {
            GameManager.Instance.selectedCase = boardPos;
            return true;
        }
        return false;
    }

    public int ConquestCost(int boardPos)
    {
        int cost = 2;
        BoardCase b = GameManager.Instance.board.boardCases[boardPos];

        if (b.haveFortresse) { cost++; }
        if (b.haveTrollLair) { cost++; }
        if (b.type == BoardCase.CaseType.Mountain) { cost++; }
        if (b.haveSaloon) { cost++; } //en gros le jeton saloon il défend de 1
        if (b.troopsNumber != 0) { cost += b.troopsNumber; }
        cost += b.forgottenTribe * 1;
        cost += b.camping * 1;

        // test le cout en troupe pour une case puis test les condition particuliére de la race + power
        player.actualPower.ConquestCost(boardPos, ref cost, player);
        player.actualRace.ConquestCost(boardPos, ref cost, player);

        return cost < 1 ? 1 : cost;

    }

    public bool Conquest(int boardPos)
    {
        int cost = ConquestCost(boardPos);

        if (CanConquest(boardPos) && cost <= player.troopsNumber)
        {
            BoardCase b = GameManager.Instance.board.boardCases[boardPos];
            if (b.playerNumber != 0)
            {
                GameManager.Instance.players[b.playerNumber-1].troopsToRedeploy += b.troopsNumber - 1;
                if (!GameManager.Instance.playersToRedeploy.Contains(b.playerNumber) && b.troopsNumber - 1 > 0)
                {
                    GameManager.Instance.playersToRedeploy.Add(b.playerNumber);
                }
            }
            player.actualRace.Conquest(boardPos,player);
            player.actualPower.Conquest(boardPos, player); //on prend en compte les pouvoirs dans la phase conquest
            player.conquestedCase.Add(boardPos);
            b.troopsNumber = 0;
            b.troopsNumber = cost;
            b.raceType = player.actualRace.type;
            b.playerNumber = player.playerNumber;
            player.troopsNumber -= cost;
            BoardCaseScript[] objscript = UnityEngine.Object.FindObjectsOfType<BoardCaseScript>();// creer un tableau des objets de la scene ayant un boardcasescript (les cases)

        /*    for (int i = 0; i < cost; i++)//tant que i est inferieur au cout
            {
                
                GameObject t = GameObject.Instantiate(GameManager.Instance.token,); //instancie un jeton
                
                foreach(BoardCaseScript go in objscript)//parcours le tableau d'objets jusqu'a ↓↓↓
                {
                    if(GameManager.Instance.selectedCase == go.CaseId)// ce que la case selectionné a le meme CaseId qu'une case du tableau
                    {
                        t.transform.position = go.transform.position; //alors la position du jeton est egale a la position de la case
                        t.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", GameManager.Instance.albedo[GameManager.Instance.activePlayerNumber-1]);//applique a l'albedo la texture ayant le numéro du joueur dans la liste de texture (GameManager)
                        t.transform.eulerAngles = new Vector3(t.transform.rotation.x, UnityEngine.Random.Range(0f, 360f), t.transform.rotation.z);// donne une rotation aléatoire sur y au jeton
                        
                        if (i > 0)
                        {
                            t.transform.position = new Vector3(t.transform.position.x + 0f,t.transform.position.y + i * 0.05f,t.transform.position.z + 0f);//superpose les jetons
                            t.transform.position = new Vector3(t.transform.position.x + UnityEngine.Random.Range(-0.1f, 0.1f), t.transform.position.y, t.transform.position.z + UnityEngine.Random.Range(-0.1f, 0.1f));// donne des random position au jeton pour donner un effet plus realiste
                            
                        }
                        t.transform.position = t.transform.position + new Vector3(go.decalageX, 0, go.decalageZ);
                       
                    
                }
               if (t.GetComponent<Renderer>().material.GetTexture("_MainTex",GameManager.Instance.albedo[] =!))
                
            }*/
            GameManager.Instance.refreshUis();
            this.Exit();
            
            return true;
            
        }

        // conqueête de la zone
        return false;
    }
}
