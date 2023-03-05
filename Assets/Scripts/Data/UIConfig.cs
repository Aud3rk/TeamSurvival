using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    [ApplicationSurvive, Unique]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private GameObject _rootUIElement;
        [Space]
        [SerializeField] private GameObject _mainMenuPrefab;
        [SerializeField] private GameObject _gamePlayMenu;
        [SerializeField] private GameObject _gameOverMenu;

        public GameObject GameOverMenu => _gameOverMenu;

        public GameObject MainMenuPrefab => _mainMenuPrefab;

        public GameObject RootUIElement => _rootUIElement;

        public GameObject GamePlayMenu => _gamePlayMenu;
    }
}