using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float _timer;
    private float _timeCD=2;
    
    void Start()
    {
        _timer = _timeCD;
    }

    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            CreateApple();
            _timer = Random.Range(45, 60);
        }
    }

    private void CreateApple()
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.isEnemy = true;
        entity.AddResource(Contexts.sharedInstance.applicationSurvive.gameSetup.value.enemy);
        entity.AddInitalPosition(transform.position);
        entity.AddHealth(70, 70);
    }
}
