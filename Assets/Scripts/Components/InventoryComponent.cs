using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using EventType = Entitas.CodeGeneration.Attributes.EventType;

[Event(EventTarget.Any, EventType.Added)]
[Game]
public class InventoryComponent : IComponent
{
    public int woodCount = 0;
    public int appleCount = 0;
}