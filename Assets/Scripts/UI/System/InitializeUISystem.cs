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
            CreateUIRoot(_contexts.applicationSurvive.uIConfig.value.RootUIElement);
            AddNewUIEntity(_contexts.applicationSurvive.uIConfig.value.GamePlayMenu);
            AddNewUIEntity(_contexts.applicationSurvive.uIConfig.value.MainMenuPrefab);
        }

        private void CreateUIRoot(GameObject rootPrefab)
        {
            ApplicationSurviveEntity uiEntity = _contexts.applicationSurvive.CreateEntity();
            _rootObject = Object.Instantiate(rootPrefab);
            uiEntity.AddView(_rootObject);
            _rootObject.Link(uiEntity);
            _rootObject.SetActive(true);//Activate when ui will work
        }

        private void AddNewUIEntity(GameObject prefab)
        {
            ApplicationSurviveEntity uiEntity  = _contexts.applicationSurvive.CreateEntity();
            uiEntity.AddResource(prefab);
            uiEntity.AddParent(_rootObject);
        }
    }
}