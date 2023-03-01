using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, ApplicationSurvive]
public class ViewComponent : IComponent
{
   [EntityIndex]
   public GameObject value;
}
