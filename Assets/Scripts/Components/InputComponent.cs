using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class InputComponent : IComponent
{
    public Vector3 moveDir;
    public Vector3 lookDir;

}
