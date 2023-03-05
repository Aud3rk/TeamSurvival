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
            var damagedRecivedEntity = _contexts.game.GetEntitiesWithView(damageReceiver).SingleEntity();
            damagedRecivedEntity.health.healthCurrent -= damage;
            if (damagedRecivedEntity.health.healthCurrent <= 0)
            {
                if (damagedRecivedEntity.hasDropLoot)
                {
                    if (damagedRecivedEntity.isTree)
                    {
                        var wood = _contexts.game.CreateEntity();
                        wood.AddResource(_contexts.applicationSurvive.gameSetup.value.wood);
                        wood.isWood = true;
                        wood.AddInitalPosition(damageReceiver.transform.position+Vector3.up);
                    }
                }
                if (!damagedRecivedEntity.isPlayer)
                {
                    damagedRecivedEntity.isRemoveEntity = true;
                }

                damagedRecivedEntity.isDied = true;
                damagedRecivedEntity.isToDestroy = true;
            }
            entity.Destroy();
        }
    }
   
}
