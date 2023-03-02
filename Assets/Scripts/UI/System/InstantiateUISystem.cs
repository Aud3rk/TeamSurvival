using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace UI.System
{
    public class InstantiateUISystem : ReactiveSystem<ApplicationSurviveEntity>
    {
        private Contexts _contexts;

        public InstantiateUISystem(Contexts context) : base(context.applicationSurvive)
        {
            _contexts = context;
        }


        protected override ICollector<ApplicationSurviveEntity> GetTrigger(IContext<ApplicationSurviveEntity> context)
        {
            return context.CreateCollector(ApplicationSurviveMatcher.Resource);
        }

        protected override bool Filter(ApplicationSurviveEntity entity)
        {
            return entity.hasResource && entity.hasUIDefaultActive;
        }

        protected override void Execute(List<ApplicationSurviveEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gameObject = Object.Instantiate(entity.resource.prefab);
                entity.AddView(gameObject);
                gameObject.Link(entity);
                gameObject.SetActive(entity.uiDefaultActive.active);
                if (entity.hasParent)
                {
                    gameObject.transform.SetParent(entity.parent.gameObject.transform);
                }
            }

        }
    }
}