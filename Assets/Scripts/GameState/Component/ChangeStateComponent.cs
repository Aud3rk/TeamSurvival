using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace GameState.Component
{
    [ApplicationSurvive, Cleanup(CleanupMode.DestroyEntity)]
    public class ChangeStateComponent : IComponent
    {
        public bool changeState;
    }
}