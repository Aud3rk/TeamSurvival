using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using Unity.VisualScripting;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public InstantiateViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameObject = Object.Instantiate(entity.resource.prefab);
            entity.AddView(gameObject);
            gameObject.Link(entity);
            if (entity.hasParent)
            {
                gameObject.transform.SetParent(entity.parent.gameObject.transform);
            }
            if (entity.hasForce)
            {
                var rb = gameObject.GetComponent<Rigidbody>();
                rb.AddForce(entity.force.direction*entity.force.force,ForceMode.Impulse);
            }
        }
    }
}