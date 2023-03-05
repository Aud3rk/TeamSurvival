using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using GameState.Component;
using UI.Data;
using UnityEngine;

namespace GameState.System
{
    //Сменяет состояния игры. т.е удаляет объекты из мира, когда мы заходим в меню и наоборот
    public class GameFlowSystem : ReactiveSystem<ApplicationSurviveEntity>
    {
        private Contexts _contexts;
        private GameManager _gameManager;

        public GameFlowSystem(Contexts contexts, GameManager gameManager) : base(contexts.applicationSurvive)
        {
            _contexts = contexts;
            _gameManager = gameManager;
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
                ChangeStateToMenu();
            }
        }

        private void ChangeStateToMenu()
        {
            ConfigureUI();
            ClearWorld();
        }

        private void ClearWorld()
        {
            _gameManager.DeactivateReactiveSystems();
            foreach (var gameEntity in _contexts.game.GetEntities())
            {
                if (gameEntity.hasView)
                {
                    var view = gameEntity.view.value;
                    view.Unlink();
                    GameObject.Destroy(view);
                    gameEntity.RemoveView();
                }
            }

            _contexts.game.Reset();
            _gameManager.ActivateReactSystems();
        }

        private void ConfigureUI()
        {
            var gameMenu =
                _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.GameMenu).SingleEntity();
            var mainMenu = _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.MainMenu).First();
            var gameOverMenu = _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.GameOverDialog)
                .SingleEntity();
            mainMenu.view.value.gameObject.SetActive(true);
            gameOverMenu.view.value.gameObject.SetActive(false);
            gameMenu.view.value.gameObject.SetActive(false);
        }

        private void CreateGame()
        {
            Time.timeScale = 1;
            var gameMenu =
                _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.GameMenu).SingleEntity();
            var mainMenu = _contexts.applicationSurvive.GetEntitiesWithUIDialogName(UiDialogName.MainMenu).First();
            mainMenu.view.value.gameObject.SetActive(false);
            gameMenu.view.value.gameObject.SetActive(true);
            
        }
    }
}