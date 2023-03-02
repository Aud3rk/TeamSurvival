using Entitas;
using UnityEngine;

public class InitializeTreeSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializeTreeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddResource(_contexts.applicationSurvive.gameSetup.value.tree);
        entity.isTree = true;
        entity.AddHealth(10,100);
        entity.AddInitalPosition(Vector3.zero);
        entity.AddDropLoot(Loot.wood);
    }
}
