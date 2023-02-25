using System.Collections;
using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject player;
    public GameObject enemy;
    public GameObject bonFire;
    public GameObject wood;
    public float speed=10f;
    public float sensivityX = 2f;
    public float sensivityY = 5f;
}
