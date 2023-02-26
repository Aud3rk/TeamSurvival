using Entitas;
using UnityEngine;

public class TakeItemSystem : IExecuteSystem
{
    private Contexts _contexts;
    private string RESOURCE_TAG = "Resource";
    public TakeItemSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 point = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag(RESOURCE_TAG))
                {
                    var entityGameObject = hit.transform.gameObject;
                    var entity = _contexts.game.GetEntitiesWithView(entityGameObject).SingleEntity();
                    if(entity.isWood)
                    {
                        _contexts.game.playerEntity.ReplaceInventory(_contexts.game.playerEntity.inventory.woodCount+1,
                        _contexts.game.playerEntity.inventory.appleCount);}
                    else 
                        _contexts.game.playerEntity.ReplaceInventory(_contexts.game.playerEntity.inventory.woodCount,
                            _contexts.game.playerEntity.inventory.appleCount+1);
                    entity.isToDestroy = true;
                }
            }
        }
    }
}
