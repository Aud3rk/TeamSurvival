using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    private Animator _animation;
    

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            _animation.SetTrigger("Play");
    }

    
}
