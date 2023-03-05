
using GameState.System;
using UI.System;

namespace Survive
{
    //All systems which works with all app
    public class ApplicationFeature : Feature
    {
        public ApplicationFeature(Contexts contexts,GameManager gameManager) : base("Application")
        {
            Add(new InitializeUISystem(contexts));
            Add(new InstantiateUISystem(contexts));
            Add(new InstantiateViewSystem(contexts));
            Add(new GameFlowSystem(contexts, gameManager ));
        }
    }
}