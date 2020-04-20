using System.Collections;
using System.Collections.Generic;

public class DecliningPhase : PlayerPhase
{
    public DecliningPhase()
    {
        this.phaseName = "DecliningPhase";
        GameManager.Instance.selectedCase = -1;
        GameManager.Instance.refreshUis();
    }

    public override bool doAction(Player player, Action act)
    {
        switch (act.type)
        {
            case Action.ActionType.MapAction:
                this.Exit();
                player.phase = new ConquestPhase();
                player.phase.Enter(player);
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
        Declining();

    }
    public override void Exit()
    {

    }

    public void Declining()
    {
        player.decliningRace = player.actualRace;
        player.actualRace.Declin(player);
        player.actualPower.Declin(player);
        player.actualRace = null;
        player.actualPower = null;
        player.troopsNumber = 0;
        foreach (int pos in player.conquestedCase)
        {
            GameManager.Instance.board.boardCases[pos].racePhase = Race.RacePhase.Declin;
        }
        player.victoryPoint += VictoryPointGain();
        player.conquestedCaseDeclin = new List<int>(player.conquestedCaseDeclin);
        player.conquestedCase.Clear();
        this.Exit();
        player.phase = new SelectRaceAndPowerPhase ();
        player.phase.Enter(player);
        GameManager.Instance.NextPlayer();
    }

    public int VictoryPointGain()
    {
        int number = 0;
        number += player.conquestedCaseDeclin.Count;
        number += player.decliningRace.VictoryPointGain(player);
        return number;
    }

}
