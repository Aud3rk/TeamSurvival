using System;
using System.Collections.Generic;
using Entitas;
using GameState.Component;

namespace GameState.System
{
    //Сменяет состояния игры. т.е удаляет объекты из мира, когда мы заходим в меню и наоборот
    public class GameFlowSystem : ReactiveSystem<ApplicationSurviveEntity>
    {
        private Contexts _contexts;

        public GameFlowSystem(Contexts contexts) : base(contexts.applicationSurvive)
        {
            _contexts = contexts;
        }


        protected override ICollector<ApplicationSurviveEntity> GetTrigger(IContext<ApplicationSurviveEntity> context)
        {
            return context.CreateCollector(ApplicationSurviveMatcher.ChangeState);
        }

        protected override bool Filter(ApplicationSurviveEntity entity)
        {
            return true;
        }

        protected override void Execute(List<ApplicationSurviveEntity> entities)
        {
            if (_contexts.applicationSurvive.stateGame.value.gameState == GameStateType.Game)
            {
                CreateGame();
            }
            else
            {
                GoToMenu();
            }
        }

        private void GoToMenu()
        {
            _contexts.game.DestroyAllEntities();
        }

        private void CreateGame()
        {
        }
    }
}