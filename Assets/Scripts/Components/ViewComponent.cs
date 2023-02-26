using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Ui]
public class ViewComponent : IComponent
{
   [EntityIndex]
   public GameObject value;
}
