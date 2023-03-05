using System.Collections;
using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[ApplicationSurvive, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject player;
    public GameObject enemy;
    public GameObject bonFire;
    public GameObject wood;
    public GameObject apple;
    public GameObject treeApple;
    public GameObject treeOat;
    public GameObject appleForAntimation;
    public GameObject treePines;
    public GameObject treePines2;
    public GameObject enemySpawner;
    public List<Vector3> enemySpawnerPosition;
    public List<Vector3> appleTree;
    public List<Vector3> oatsTree;
    public List<Vector3> pines1Tree;
    public List<Vector3> pines2Tree;

    
    
    public float speed=10f;
    public float sensivityX = 2f;
    public float sensivityY = 5f;
}
