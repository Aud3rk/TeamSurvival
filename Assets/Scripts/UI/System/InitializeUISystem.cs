using Entitas;
using UnityEngine;

namespace UI.System
{
    public class InitializeUISystem : IInitializeSystem
    {
        //UI works like example in doc:
        //sample: https://github.com/RomanZhu/Match-Line-Entitas-ECS/blob/master/Assets/Sources/View/UI/UIRestartView.cs

        private Contexts _contexts;
        private GameObject _rootObject;

        public InitializeUISystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            AddNewEntity(_contexts.game.uIConfig.value.GamePlayMenu);
            AddNewEntity(_contexts.game.uIConfig.value.MainMenuPrefab);
            CreateUIRoot(_contexts.game.uIConfig.value.RootUIElement);
        }

        private void CreateUIRoot(GameObject rootPrefab)
        {
            GameEntity gameEntity = _contexts.game.CreateEntity();
            _rootObject = Object.Instantiate(rootPrefab);
            gameEntity.AddView(_rootObject);
            gameEntity.isUIComponentRoot = true;
        }

        private void AddNewEntity(GameObject prefab)
        {
            GameEntity gameEntity = _contexts.game.CreateEntity();
            gameEntity.isUIComponentFlag = true;
            gameEntity.AddResource(prefab);
            gameEntity.AddParent(_rootObject);
        }
    }
}