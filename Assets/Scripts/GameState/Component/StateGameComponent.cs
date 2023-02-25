using Entitas.CodeGeneration.Attributes;

namespace GameState.Component
{
    [Game, Unique]
    public class StateGameComponent
    {
        public GameStateType gameState;
    }
}