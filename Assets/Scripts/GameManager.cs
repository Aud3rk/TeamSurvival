using System;
using Data;
using Entitas;
using GameState.Component;
using Survive;
using UnityEngine;
using StateGameComponent = GameState.Component.StateGameComponent;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSetup _gameSetup;

    [SerializeField] private UIConfig _uiConfig;


    private Systems _applicationSystems;

    private void Start()
    {
        var context = Contexts.sharedInstance;

        var applicationSurviveEntity = context.applicationSurvive.CreateEntity();
        applicationSurviveEntity.AddUIConfig(_uiConfig);
        applicationSurviveEntity.AddGameSetup(_gameSetup);
        applicationSurviveEntity.AddStateGame(new GameState.Component.StateGameComponent());
        
        _applicationSystems = CreateSystems(context);
        _applicationSystems.Initialize();
    }

    private void Update()
    {
        _applicationSystems.Execute();
    }
  
    private Systems CreateSystems(Contexts contexts)
    {
        return 
            new ApplicationFeature(contexts)
            .Add(new GameFeature(contexts));
    }
}