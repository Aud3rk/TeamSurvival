using System;
using UI.System;

namespace Survive
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts) : base("game")
        {
            Add(new InitializePlayerSystem(contexts));
            Add(new InitializePositionSystem(contexts));
            Add(new InitializeBonfireSystem(contexts));
            Add(new InitializeAppleSystem(contexts));
            Add(new InitializeTreeSystem(contexts));
            Add(new InitializeWoodSystem(contexts));
            Add(new AnyInventoryEventSystem(contexts));
            Add(new AnyActualTimerEventSystem(contexts));
            Add(new InitializeEnemySystem(contexts));
            Add(new GameOverSystem(contexts));

            Add(new InputSystem(contexts));
            Add(new MoveSystem(contexts));
            Add(new DamageProviderSystem(contexts));
            Add(new BurningSystem(contexts));
            Add(new AddingWoodToBonfireSystem(contexts));
            Add(new TakeItemSystem(contexts));
            Add(new DestroySystem(contexts));
            Add(new DropWoodSystem(contexts));
            Add(new BurningWoodSystem(contexts));
            Add(new PlayerAttackSystem(contexts));
            Add(new HealthProviderSystem(contexts));
            Add(new AppleEatSystem(contexts));
            Add(new UIUpdateListenerSystem(contexts));
        }
    }
}