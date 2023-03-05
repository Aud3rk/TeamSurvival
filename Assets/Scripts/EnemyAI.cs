using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private float _coolDownTime = 4f;
    private Animator _animator;
    private bool isDestroyed;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Contexts.sharedInstance.game.playerEntity.hasView)
        {
            _navMeshAgent.destination = Contexts.sharedInstance.game.playerEntity.view.value.transform.position;
            Attack(); 
        }
    }

    private void Attack()
    {
        if (isDestroyed)
        {
            return;
        }

        _coolDownTime -= Time.deltaTime;
        if (IsInAttackDistance())
        {
            if (_coolDownTime <= 0)
            {
                _animator.SetTrigger("Attack");
                _coolDownTime = 5f;
                var entity = Contexts.sharedInstance.game.CreateEntity();
                entity.AddDamage(Contexts.sharedInstance.game.playerEntity.view.value.gameObject, 15);
            }
        }
    }

    private void OnDestroy()
    {
        isDestroyed = true;
    }

    private bool IsInAttackDistance()
    {
        return (Vector3.Distance(transform.position,
            Contexts.sharedInstance.game.playerEntity.view.value.transform.position) < 2f);
    }
}