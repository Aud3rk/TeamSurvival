using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ECSGuide.ECS
{
    public class EnemyData : ScriptableObject
    {
        public GameObject enemyPrefab;
        public float speedEnemy = 3f;
        
        public static EnemyData LoadFromAssets() => Resources.Load("Data/EnemyData") as EnemyData ; 
    }
}

