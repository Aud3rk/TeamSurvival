using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DamageProviderSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public DamageProviderSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage);
    }

    protected override bool Filter(GameEntity entity)
    { 
        return entity.hasDamage;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var damageReceiver = entity.damage.damageReceiver;
            var damage = entity.damage.damage;
            var damageReceiverIndex = _contexts.game.GetEntitiesWithView(damageReceiver).SingleEntity();
            damageReceiverIndex.health.healthCurrent -= damage;
            if (damageReceiverIndex.health.healthCurrent <= 0)
            {
                if (damageReceiverIndex.hasDropLoot)
                {
                    if (damageReceiverIndex.isTree)
                    {
                        var wood = _contexts.game.CreateEntity();
                        wood.AddResource(_contexts.game.gameSetup.value.wood);
                        wood.isWood = true;
                        wood.AddInitalPosition(damageReceiver.transform.position);
                    }
                }
                damageReceiverIndex.isToDestroy = true;
            }
            entity.Destroy();
        }
    }
   
}
