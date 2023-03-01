using Entitas;
using UnityEngine;

public class DropWoodSystem : IExecuteSystem
{
    private Contexts _contexts;

    public DropWoodSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var woodCount = _contexts.game.playerEntity.inventory.woodCount;
            if (woodCount > 0)
            {
                woodCount--;
                var entity = _contexts.game.CreateEntity();
                entity.AddResource(_contexts.game.gameSetup.value.wood);
                entity.AddInitalPosition(_contexts.game.playerEntity.view.value.transform.localPosition +
                                         _contexts.game.playerEntity.view.value.transform.forward);
                entity.AddForce(_contexts.game.playerEntity.view.value.transform.forward.normalized, 5);
                entity.isWood = true;
                _contexts.game.playerEntity.ReplaceInventory(woodCount,
                       _contexts.game.playerEntity.inventory.appleCount);
            }
        }
    }
}
