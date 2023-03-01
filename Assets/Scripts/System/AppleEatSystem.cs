using Entitas;
using UnityEngine;

public class AppleEatSystem : IExecuteSystem
{
    private Contexts _contexts;

    public AppleEatSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            var appleCount = _contexts.game.playerEntity.inventory.appleCount;
            if (appleCount > 0)
            {
                appleCount--;
                var enity = _contexts.game.CreateEntity();
                enity.AddHeal(_contexts.game.playerEntity,10);
                var appleAnim =Object.Instantiate(_contexts.applicationSurvive.gameSetup.value.appleForAntimation,_contexts.game.playerEntity.view.value.transform);
                Object.Destroy(appleAnim,1f);
                _contexts.game.playerEntity.ReplaceInventory(_contexts.game.playerEntity.inventory.woodCount,appleCount);
                
            }
        }
    }
}
