using GameState.Component;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _continueGameButton;
        [SerializeField] private Button _exitGameButton;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartGameClick);
            _continueGameButton.onClick.AddListener(OnContinueGameClick);
            _exitGameButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnExitButtonClick()
        {
        }

        private void OnContinueGameClick()
        {
        }

        private void OnStartGameClick()
        {
            var applicationSurviveEntity = Contexts.sharedInstance.applicationSurvive.CreateEntity();
            Contexts.sharedInstance.applicationSurvive.stateGame.value.gameState = GameStateType.Game;
            applicationSurviveEntity.AddChangeState(true);
        }
    }
}