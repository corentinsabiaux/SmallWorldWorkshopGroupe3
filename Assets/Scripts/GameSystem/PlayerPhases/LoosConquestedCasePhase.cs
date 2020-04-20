using UnityEngine;
public class LoosConquestedCasePhase : PlayerPhase
{
    public LoosConquestedCasePhase()
    {
        this.phaseName = "LoosConquestedCasePhase";

        GameManager.Instance.selectedCase = -1;
        GameManager.Instance.refreshUis();
    }

    public int basePlayerTurn { get; set; }
    public PlayerPhase basePlayerPhase { get; set; }
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
            default:
                return false;
                break;
        }
    }

    public override void Enter(Player player)
    {
        this.player = player;
        GameManager.Instance.refreshUis();
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
            if (player.conquestedCase.Contains(GameManager.Instance.selectedCase))
            {
                if (player.troopsToRedeploy >= number)
                {
                    player.troopsToRedeploy -= number;
                    GameManager.Instance.board.boardCases[GameManager.Instance.selectedCase].troopsNumber += number;
                }
                if (player.troopsToRedeploy == 0)
                {
                    this.Exit();
                    player.phase = basePlayerPhase;
                    GameManager.Instance.playersToRedeploy.RemoveAt(0);
                    GameManager.Instance.activePlayerNumber = basePlayerTurn;
                    GameManager.Instance.players[basePlayerTurn].doAction(new Action(Action.ActionType.EndOfTurnAction, -1));
                    return true;
                }
                return true;
            }
        }
        return false;
    }
}
