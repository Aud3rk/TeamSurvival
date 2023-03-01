using Entitas.CodeGeneration.Attributes;

namespace GameState.Component
{
    [ApplicationSurvive, Unique]
    public class StateGameComponent
    {
        public GameStateType gameState;
    }
}