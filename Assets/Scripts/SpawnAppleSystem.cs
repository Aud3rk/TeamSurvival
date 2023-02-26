using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAppleSystem : MonoBehaviour
{
    [SerializeField]private GameObject _applePrefab;
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
            _timer = Random.Range(15, 30);
        }
    }

    private void CreateApple()
    {
        var entity =Contexts.sharedInstance.game.CreateEntity();
        entity.AddResource(_applePrefab);
        entity.isApple = true;
        entity.AddInitalPosition(transform.forward);
    }
}
