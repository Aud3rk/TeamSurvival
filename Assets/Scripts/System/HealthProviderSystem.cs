using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HealthProviderSystem : ReactiveSystem<GameEntity>
{
    
    private Contexts _contexts;
    public HealthProviderSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Heal);
    }

    protected override bool Filter(GameEntity entity)
    { 
        return entity.hasHeal;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var healReceiver = entity.heal.healReceiver;
            var heal = healReceiver.health.healthCurrent + 10;
            healReceiver.ReplaceHealth(Mathf.Min(heal,healReceiver.health.healthMax),healReceiver.health.healthMax);
            entity.Destroy();   
        }
    }
}
