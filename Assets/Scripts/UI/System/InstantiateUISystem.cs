using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace UI.System
{
    public class InstantiateUISystem : ReactiveSystem<UiEntity>
    {
        private Contexts _contexts;

        public InstantiateUISystem(Contexts context) : base(context.ui)
        {
            _contexts = context;
        }


        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.Resource);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.hasResource;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gameObject = Object.Instantiate(entity.resource.prefab);
                entity.AddView(gameObject);
                gameObject.Link(entity);
                if (entity.hasParent)
                {
                    gameObject.transform.SetParent(entity.parent.gameObject.transform);
                }
            }

        }
    }
}