using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddingWoodToBonfireSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public AddingWoodToBonfireSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AddingSeconds);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAddingSeconds;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
           _contexts.game.bonfireEntity.ReplaceActualTimer(_contexts.game.bonfireEntity.actualTimer.seconds
                                                          +entity.addingSeconds.seconds);
           entity.RemoveAddingSeconds();
        }
    }
}
