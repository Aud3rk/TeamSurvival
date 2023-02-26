using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDrop : MonoBehaviour
{
    [SerializeField] private GameObject _woodPrefab;

    public GameEntity CreateLoot(Loot loot)
    {
        GameEntity drop = new GameEntity();
        switch (loot)
        {
            case Loot.wood:
                drop = CreateWood();
                break;
        }

        return drop;
    }
    public GameEntity CreateWood()
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddResource(_woodPrefab);
        entity.isApple = true;
        entity.AddInitalPosition(Vector3.zero);
        return entity;
    }
}
