using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HealComponent : IComponent
{
    public GameEntity healReceiver;
    public float healPointl;
}
