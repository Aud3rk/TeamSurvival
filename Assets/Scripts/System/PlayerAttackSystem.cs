using UnityEngine;
using Entitas;

public class PlayerAttackSystem : IExecuteSystem
{
    private Contexts _contexts;
    private string DAMAGEABLE_TAG = "Damageable";

    public PlayerAttackSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3 point = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag(DAMAGEABLE_TAG))
                {
                    var entity = _contexts.game.CreateEntity();
                    entity.AddDamage(hit.transform.gameObject, 10);
                }
            }
        }
    }
}
