using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private float _timeCD = 4f;
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Contexts.sharedInstance.game.playerEntity.hasView)
            _navMeshAgent.destination = Contexts.sharedInstance.game.playerEntity.view.value.transform.position;
        Attack();
    }
    
    private void Attack()
    {
        _timeCD -= Time.deltaTime;
        if (inDistance())
        {
            if (_timeCD <= 0)
            {
                _timeCD = 5f;
                var entity = Contexts.sharedInstance.game.CreateEntity();
                entity.AddDamage(Contexts.sharedInstance.game.playerEntity.view.value.gameObject, 15);
            }
        }
    }

    private bool inDistance()
    {
        return (Vector3.Distance(transform.position,
            Contexts.sharedInstance.game.playerEntity.view.value.transform.position) < 2f);
    }
}
