using GameState.Component;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class GameOverMenuView : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _goToMenuButton;

        private void Awake()
        {
            _goToMenuButton.onClick.AddListener(OnGoToMenuButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnGoToMenuButtonClick()
        {
            var applicationSurviveEntity = Contexts.sharedInstance.applicationSurvive.CreateEntity();
            Contexts.sharedInstance.applicationSurvive.stateGame.value.gameState = GameStateType.Menu;
            applicationSurviveEntity.AddChangeState(true);
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}