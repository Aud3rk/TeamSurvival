using UnityEngine;
using Entitas;
public class DropLootComponent : IComponent
{
    public Loot loot;
}

public enum Loot
{
    wood,
    apple
}
