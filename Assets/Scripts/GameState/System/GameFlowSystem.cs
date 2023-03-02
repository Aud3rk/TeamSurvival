using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using GameState.Component;
using UI.Data;

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
            var gameMenu =
                _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.GameMenu).First();
            var mainMenu = _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.MainMenu).First();
            mainMenu.view.value.gameObject.SetActive(true);
            gameMenu.view.value.gameObject.SetActive(false);
            _contexts.game.DestroyAllEntities();
        }

        private void CreateGame()
        {
            var gameMenu =
                _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.GameMenu).First();
            var mainMenu = _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.MainMenu).First();
            mainMenu.view.value.gameObject.SetActive(false);
            gameMenu.view.value.gameObject.SetActive(true);
        }
    }
}