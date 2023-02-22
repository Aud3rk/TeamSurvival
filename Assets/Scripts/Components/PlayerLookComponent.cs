using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
[Game, Unique]
public class PlayerLookComponent : IComponent
{
   public Vector3 value;
}
