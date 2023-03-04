using UnityEngine;
using Entitas;

public class PlayerAttackSystem : IExecuteSystem
{
    private Contexts _contexts;
    private string DAMAGEABLE_TAG = "Damageable";
    private float _timeCD = 2f;
    

    public PlayerAttackSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        _timeCD -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(_timeCD<=0)
            {
                _timeCD = 2f;
                Ray ray = new Ray(_contexts.game.playerEntity.view.value.transform.position,
                    _contexts.game.playerEntity.view.value.transform.forward);
                /*Vector3 point = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
                Ray ray = Camera.main.ScreenPointToRay(point);*/
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 2))
                {
                    if (hit.transform.gameObject.CompareTag(DAMAGEABLE_TAG))
                    {
                        var entity = _contexts.game.CreateEntity();
                        entity.AddDamage(hit.transform.gameObject, 20);
                    }
                }
            }
        }
    }
}
