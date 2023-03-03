using System.Collections.Generic;
using Entitas;
using GameState.Component;
using UnityEngine;

public class InitializeEnemySystem : ReactiveSystem<ApplicationSurviveEntity>
{
    private Contexts _contexts;


    public InitializeEnemySystem(Contexts contexts) : base(contexts.applicationSurvive)
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
        var entity = _contexts.game.CreateEntity();
        entity.isEnemy = true;
        entity.AddResource(_contexts.applicationSurvive.gameSetup.value.enemy);
        entity.AddInitalPosition(new Vector3(-15, -2, -1));
        entity.AddHealth(70, 70);

    }
}