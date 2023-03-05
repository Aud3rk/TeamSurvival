using Entitas;
using UnityEngine;

public class InitializeTreeSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializeTreeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var listAppleTree = _contexts.applicationSurvive.gameSetup.value.appleTree;
        foreach (var treePos in listAppleTree)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddResource(_contexts.applicationSurvive.gameSetup.value.treeApple);
            entity.isTree = true;
            entity.AddHealth(10,100);
            entity.AddInitalPosition(treePos);
            entity.AddDropLoot(Loot.wood);
        }

        var listOatsTree = _contexts.applicationSurvive.gameSetup.value.oatsTree;
        foreach (var treePos in listOatsTree)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddResource(_contexts.applicationSurvive.gameSetup.value.treeOat);
            entity.isTree = true;
            entity.AddHealth(10,100);
            entity.AddInitalPosition(treePos);
            entity.AddDropLoot(Loot.wood);
        }
        
        var listPines1Tree = _contexts.applicationSurvive.gameSetup.value.pines1Tree;
        foreach (var treePos in listPines1Tree)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddResource(_contexts.applicationSurvive.gameSetup.value.treePines);
            entity.isTree = true;
            entity.AddHealth(10,100);
            entity.AddInitalPosition(treePos);
            entity.AddDropLoot(Loot.wood);
        }
    }
}
