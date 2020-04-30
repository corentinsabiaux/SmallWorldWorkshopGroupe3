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
            case Action.ActionType.SkeletonAction:
                if (p.victoryPoint > 0 && p.troopsNumber < p.actualRace.troopsMax)
                {
                    p.victoryPoint -= 1;
                    p.troopsNumber += 1;
                    GameManager.Instance.refreshUis();
                } else
                {
                    Debug.LogError("Conversion impossible, victoryPoint < 1 && p.troopsNumber < p.actualRace.troopsMax");

                }
                return true;
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
            player.conquestedCase.Add(boardPos);
            b.troopsNumber = cost;
            b.raceType = player.actualRace.type;
            b.playerNumber = player.playerNumber;
            player.troopsNumber -= cost;

            this.Exit();

            return true;
        }

        // conqueête de la zone
        return false;
    }
}
