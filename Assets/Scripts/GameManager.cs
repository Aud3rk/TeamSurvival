using System;
using Data;
using Entitas;
using UI.System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSetup _gameSetup;

    [SerializeField] private UIConfig _uiConfig;


    private Systems _systems;

    private void Start()
    {
        var context = Contexts.sharedInstance;

        var entity = context.game.CreateEntity();
        entity.AddGameSetup(_gameSetup);
        entity.AddUIConfig(_uiConfig);

        _systems = CreateSystems(context);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }
  
    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializeUISystem(contexts))
            .Add(new InstantiateUISystem(contexts))
            .Add(new InstantiateViewSystem(contexts))
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InitializePositionSystem(contexts))
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
            .Add(new InitializeAppleSystem(contexts))
            .Add(new InitializeTreeSystem(contexts))
            .Add(new PlayerAttackSystem(contexts));
    }
}