using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BurningWoodSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public BurningWoodSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BurnedWood);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBurnedWood;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameObject gameObject = entity.burnedWood.wood;
            var woodEntity = _contexts.game.GetEntitiesWithView(gameObject).SingleEntity();
            woodEntity.isToDestroy = true;
            var bonfire = _contexts.game.bonfireEntity;
            bonfire.AddAddingSeconds(20);
            
        }
    }
}
