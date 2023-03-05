using System.Collections.Generic;
using Entitas;

namespace UI.System
{
    public class UIUpdateListenerSystem :  ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public UIUpdateListenerSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Player);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var applicationSurviveEntity in _contexts.applicationSurvive.GetGroup(ApplicationSurviveMatcher.UIUpdateListeners))
            {
                applicationSurviveEntity.uIUpdateListeners.updateListeners.UpdateListeners();
            }
        }
    }
}