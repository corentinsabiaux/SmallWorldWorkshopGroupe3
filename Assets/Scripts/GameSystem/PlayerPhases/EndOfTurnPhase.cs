using UnityEngine;
public class EndOfTurnPhase : PlayerPhase
{
    public EndOfTurnPhase()
    {
        this.phaseName = "EndOfTurnPhase";
        GameManager.Instance.selectedCase = -1;
        GameManager.Instance.refreshUis();
    }

    public override bool doAction(Player player, Action act)
    {
        switch (act.type)
        {
            case Action.ActionType.MapAction:
                Redeployment(act.index, act.number);
                return false;
                break;
            case Action.ActionType.UnselectAction:
                GameManager.Instance.selectedCase = -1;
                GameManager.Instance.refreshUis();
                return true;
                break;
            case Action.ActionType.EndOfTurnAction:
                player.victoryPoint += VictoryPointGain();
                if (GameManager.Instance.playersToRedeploy.Count == 0)
                {
                    this.Exit();
                    player.phase = new StartOfTurnPhase();
                    Debug.Log(" Player go to : "+player.phase);
                    player.phase.Enter(player);
                    GameManager.Instance.NextPlayer();
                    return true;
                }
                else
                {  
                    Player p = GameManager.Instance.players[GameManager.Instance.playersToRedeploy[0]-1];
                    LoosConquestedCasePhase phase = new LoosConquestedCasePhase();
                    phase.basePlayerTurn = GameManager.Instance.activePlayerNumber;
                    phase.basePlayerPhase = p.phase;
                    p.phase = phase;
                    p.phase.Enter(p);
                    GameManager.Instance.activePlayerNumber = GameManager.Instance.playersToRedeploy[0];
                    GameManager.Instance.refreshUis();
                    return true;
                }
                break;
            default:
                return false;
                break;
        }
    }

    public override void Enter(Player player)
    {
        this.player = player;
    }
    public override void Exit()
    {

    }

    public bool Redeployment(int boardPos, int number)
    {
        if (GameManager.Instance.selectedCase == -1)
        {
            if (player.conquestedCase.Contains(boardPos))
            {
                GameManager.Instance.selectedCase = boardPos;
                return true;
            }
        }
        else
        {
            if (player.conquestedCase.Contains(boardPos) && number > 0)
            {
                if (GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase].troopsNumber - number <= 0 )
                {
                    int i = GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase].troopsNumber - number - 1;
                    number += i;
                }
                GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase].troopsNumber -= number;
                GameManager.Instance.board.boardCases[boardPos].troopsNumber += number;
                return true;
            }
        }
        return false;
    }

    public int VictoryPointGain()
    {
        int number = 0;
        number += player.conquestedCase.Count;
        number += player.actualPower.VictoryPointGain(player);
        number += player.actualRace.VictoryPointGain(player);
        return number;
    }

}
