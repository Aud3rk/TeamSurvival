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
            CreateUIRoot(_contexts.game.uIConfig.value.RootUIElement);
            AddNewUIEntity(_contexts.game.uIConfig.value.GamePlayMenu);
            AddNewUIEntity(_contexts.game.uIConfig.value.MainMenuPrefab);
        }

        private void CreateUIRoot(GameObject rootPrefab)
        {
            GameEntity gameEntity = _contexts.game.CreateEntity();
            _rootObject = Object.Instantiate(rootPrefab);
            gameEntity.AddView(_rootObject);
            gameEntity.isUIRoot = true;
            
            _rootObject.SetActive(false);//Activate when ui will work
        }

        private void AddNewUIEntity(GameObject prefab)
        {
            //In Good time we should create ui Context and work with it 
            GameEntity gameEntity = _contexts.game.CreateEntity();
            gameEntity.AddResource(prefab);
            gameEntity.AddParent(_rootObject);
            gameEntity.isUIFlag = true;
        }
    }
}