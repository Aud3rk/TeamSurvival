using System.Collections.Generic;
using Entitas;

public class InitializePositionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public InitializePositionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InitalPosition);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        for (var i = 0; i < entities.Count; i++)
        {
            entities[i].view.value.transform.position = entities[i].initalPosition.value;
        }
    }
}