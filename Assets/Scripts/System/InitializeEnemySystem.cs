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
        foreach (var pos in _contexts.applicationSurvive.gameSetup.value.enemySpawnerPosition)
        {
            var spawner =Object.Instantiate(_contexts.applicationSurvive.gameSetup.value.enemySpawner,pos,Quaternion.identity);
        }

    }
}