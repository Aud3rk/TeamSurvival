using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    //UI works like example in doc:
    //sample: https://github.com/RomanZhu/Match-Line-Entitas-ECS/blob/master/Assets/Sources/View/UI/UIRestartView.cs
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
            
        }
    }
}