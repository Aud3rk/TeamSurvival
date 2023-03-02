using Entitas;
using UnityEngine;

public class InitializeEnemySystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializeEnemySystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isEnemyComponents = true;
        entity.AddResource(_contexts.game.gameSetup.value.enemy);
        entity.AddInitalPosition(new Vector3(-12,-1,10));
        entity.AddHealth(150,150);


        

        


    }
}
