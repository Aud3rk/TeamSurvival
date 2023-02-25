using System.Collections;
using System.Collections.Generic;
using Entitas;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameSetup _GameSetup;
    private Systems _systems;
    void Start()
    {
        var context = Contexts.sharedInstance;

        var entity = context.game.CreateEntity();
        entity.AddGameSetup(_GameSetup);
        
        
        _systems = CreateSystems(context);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new HelloWorldSystem())
            .Add(new InstantientViewSystem(contexts))
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InputSystem(contexts))
            .Add(new MoveSystem(contexts))
            .Add(new DamageProviderSystem(contexts))
            .Add(new InitializeBonfireSystem(contexts))
            .Add(new BuriningSystem(contexts))
            .Add(new InitializeWoodSystem(contexts))
            .Add(new AddingWoodToBonfireSystem(contexts))
            .Add(new TakeItemSystem(contexts))
            .Add(new DestroySystem(contexts))
            .Add(new DropWoodSystem(contexts))
            .Add(new BurningWoodSystem(contexts))
        ;
    }
}
