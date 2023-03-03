using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self, EventType.Added)]
[Game]
public class ActualTimerComponent : IComponent
{
    public float seconds;
}
