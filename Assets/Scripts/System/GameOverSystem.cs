using System.Collections.Generic;
using Entitas;
using UI.Data;
using UnityEngine;

namespace System
{
    public class GameOverSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public GameOverSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Died);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.isDied;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var entitiesWithUIDialogName = _contexts.applicationSurvive
                .GetEntitiesWithUIDialogName(UiDialogName.GameMenu).SingleEntity();
            entitiesWithUIDialogName.view.value.gameObject.SetActive(false);
            Time.timeScale = 0;

            var gameOverDialog = _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.GameOverDialog)
                .SingleEntity();
            gameOverDialog.view.value.gameObject.SetActive(true);
        }
    }
}