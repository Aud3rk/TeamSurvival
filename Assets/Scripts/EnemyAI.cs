using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Contexts.sharedInstance.game.playerEntity.hasView)
            _navMeshAgent.destination = Contexts.sharedInstance.game.playerEntity.view.value.transform.position;
    }
}
