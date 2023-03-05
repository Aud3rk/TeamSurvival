using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Any, EventType.Added)]
[Game]
public class ActualTimerComponent : IComponent
{
    public float seconds;
}
