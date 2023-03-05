using System.Collections.Generic;
using Entitas;
using GameState.Component;
using UnityEngine;

public class InitializePlayerSystem : ReactiveSystem<ApplicationSurviveEntity>
{
    private Contexts _contexts;


    public InitializePlayerSystem(Contexts contexts) : base(contexts.applicationSurvive)
    {
        _contexts = contexts;
    }

    protected override ICollector<ApplicationSurviveEntity> GetTrigger(IContext<ApplicationSurviveEntity> context)
    {
        return context.CreateCollector(ApplicationSurviveMatcher.ChangeState);
    }

    protected override bool Filter(ApplicationSurviveEntity entity)
    {
        return entity.changeState.changeState &&
               _contexts.applicationSurvive.stateGame.value.gameState == GameStateType.Game;
    }

    protected override void Execute(List<ApplicationSurviveEntity> entities)
    {
        Initialize();
    }

    private void Initialize()
    {
        _contexts.game.isPlayer = true;
        var entity = _contexts.game.playerEntity;
        entity.AddResource(_contexts.applicationSurvive.gameSetup.value.player);
        entity.AddInitalPosition(new Vector3(10, 10, 10));
        entity.AddHealth(100, 100);
        entity.AddInventory(0, 0);

    }
}