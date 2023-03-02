using UnityEngine;
using Entitas;
public class InitializeBonfireSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeBonfireSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isBonfire = true;
        entity.AddResource(_contexts.applicationSurvive.gameSetup.value.bonFire);
        entity.AddActualTimer(20f);
        entity.AddInitalPosition(new Vector3(5,-2,5));
    }
}
