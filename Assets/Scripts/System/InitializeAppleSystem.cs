using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitializeAppleSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeAppleSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddResource(_contexts.game.gameSetup.value.apple);
        entity.isApple = true;
        entity.AddInitalPosition(Vector3.zero);
    }
}
