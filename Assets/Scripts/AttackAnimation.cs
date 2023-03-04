using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    private Animator _animation;
    private float _timeCD = 4f;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            _animation.SetTrigger("Play");
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
                entity.AddDamage(Contexts.sharedInstance.game.playerEntity.view.value.gameObject, 25);
            }
        }
    }

    private bool inDistance()
    {
        return (Vector3.Distance(transform.position,
            Contexts.sharedInstance.game.playerEntity.view.value.transform.position) < 2f);
    }
}
