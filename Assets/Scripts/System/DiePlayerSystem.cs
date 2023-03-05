using System.Collections.Generic;
using Entitas;

namespace System
{
    public class DiePlayerSystem :  ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public DiePlayerSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Player);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDied;
        }

        protected override void Execute(List<GameEntity> entities)
        {
        }
    }
}