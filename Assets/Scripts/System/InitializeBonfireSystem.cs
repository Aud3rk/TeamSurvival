using System.Collections.Generic;
using UnityEngine;
using Entitas;
using GameState.Component;

public class InitializeBonfireSystem : ReactiveSystem<ApplicationSurviveEntity>
{
    private Contexts _contexts;


    public void Initialize()
    {
        _contexts.game.isBonfire = true;
        var entity = _contexts.game.bonfireEntity;
        entity.AddResource(_contexts.applicationSurvive.gameSetup.value.bonFire);
        entity.AddActualTimer(20f);
        entity.AddInitalPosition(new Vector3(5, -2, 5));
    }

    public InitializeBonfireSystem(Contexts contexts) : base(contexts.applicationSurvive)
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
}