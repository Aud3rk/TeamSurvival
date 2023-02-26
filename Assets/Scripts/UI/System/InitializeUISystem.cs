using Entitas;
using Entitas.Unity;
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
            UiEntity uiEntity = _contexts.ui.CreateEntity();
            _rootObject = Object.Instantiate(rootPrefab);
            uiEntity.AddView(_rootObject);
            _rootObject.Link(uiEntity);
            uiEntity.isUIRoot = true;
            _rootObject.SetActive(false);//Activate when ui will work
        }

        private void AddNewUIEntity(GameObject prefab)
        {
            UiEntity uiEntity  = _contexts.ui.CreateEntity();
            uiEntity.AddResource(prefab);
            uiEntity.AddParent(_rootObject);
        }
    }
}