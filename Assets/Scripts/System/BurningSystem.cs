using Entitas;
using GameState.Component;
using UnityEngine;

public class BurningSystem : IExecuteSystem
{
    private Contexts _contexts;

    public BurningSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (IsInGame())
        {
            Timer();
        }
    }

    private bool IsInGame()
    {
        return _contexts.applicationSurvive.stateGame.value.gameState == GameStateType.Game;
    }

    private void Timer()
    {
        var burningTime = _contexts.game.bonfireEntity.actualTimer.seconds;
        burningTime -= Time.deltaTime;
        if (burningTime <= 0)
        {
        }

        _contexts.game.bonfireEntity.ReplaceActualTimer(burningTime);
    }
}