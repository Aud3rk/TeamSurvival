using Entitas;
using UnityEngine;

public class InitializeWoodSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeWoodSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddResource(_contexts.game.gameSetup.value.wood);
        entity.isWood = true;
        entity.AddInitalPosition(new Vector3(2,2,2));
    }
}
