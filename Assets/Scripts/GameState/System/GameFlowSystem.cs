using System;
using System.Collections.Generic;
using Entitas;

namespace GameState.System
{
    //Сменяет состояния игры. т.е удаляет объекты из мира, когда мы заходим в меню и наоборот
    public class GameFlowSystem : ReactiveSystem<GameEntity>
    {
        public GameFlowSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public GameFlowSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}