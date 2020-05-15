public class StartOfTurnPhase : PlayerPhase
{
    public StartOfTurnPhase()
    {
        this.phaseName = "StartOfTurnPhase";
        GameManager.Instance.selectedCase = -1;
        GameManager.Instance.refreshUis();
    }

    public override bool doAction(Player player, Action act)
    {
        switch (act.type)
        {
            case Action.ActionType.MapAction:
                if (GameManager.Instance.selectedCase == -1)
                {
                    return HaveCase(act.index);
                }
                if (GameManager.Instance.selectedCase > 0 && GameManager.Instance.selectedCase < 40 && GameManager.Instance.selectedCase == act.index)
                {
                    return AbandonCase(GameManager.Instance.selectedCase);
                }
                return false;
                break;
            case Action.ActionType.UnselectAction:
                GameManager.Instance.selectedCase = -1;
                GameManager.Instance.refreshUis();
                return true;
                break;
            case Action.ActionType.StartConquestAction:
                this.Exit();
                player.phase = new ConquestPhase();
                player.phase.Enter(player);
                GameManager.Instance.refreshUis();
                return true;
                break;
            case Action.ActionType.DeclinAction:
                this.Exit();
                player.phase = new DecliningPhase();
                player.phase.Enter(player);
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
        player.actualRace.StartTurn(player);
        
    }
    public override void Exit()
    {

    }

    public void PrepareTroops()
    {
        foreach (int i in player.conquestedCase)
        {
            if (GameManager.Instance.board.boardCases[i].raceType == player.actualRace.type)
            {
                int troopsNumberTemp = GameManager.Instance.board.boardCases[i].troopsNumber;
                troopsNumberTemp = troopsNumberTemp > 1 ? troopsNumberTemp - 1 : 0;
                GameManager.Instance.board.boardCases[i].troopsNumber = 1;
                player.troopsNumber += troopsNumberTemp;
            }
        }
    }

    public bool HaveCase(int boardPos)
    {
        if (player.conquestedCase.Contains(boardPos))
        {
            GameManager.Instance.selectedCase = boardPos;
            return true;
        }
        return false;
    }

    public bool AbandonCase(int boardPos)
    {
        player.conquestedCase.Remove(boardPos);
        player.troopsNumber += 1;
        GameManager.Instance.board.boardCases[boardPos].troopsNumber = 0;
        GameManager.Instance.board.boardCases[boardPos].playerNumber = 0;
        GameManager.Instance.board.boardCases[boardPos].raceType = Race.RaceType.nothing;
        player.actualRace.LoosConquestedCase(boardPos, player);
        player.actualPower.LoosConquestedCase(boardPos, player);
        if (player.conquestedCase.Count == 0)
        {
            this.Exit();
            player.phase = new FirstConquestPhase();
            player.phase.Enter(player);
        }
         GameManager.Instance.selectedCase = -1;
        return true;
    }
}
