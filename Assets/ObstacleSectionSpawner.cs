using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSectionSpawner : MonoBehaviour
{
    public static ObstacleSectionSpawner instance;
    [SerializeField] private float obstacleSpawnDistance = 26f;
    private void Awake()
    {
        instance = this;  
    }

    public void SpawnObstacleSection()
    {
        ObjectPooler.instance.SpawnFromPool("obstacleSection", new Vector3(0,0, obstacleSpawnDistance), new Quaternion(0,0,0,0));
        ObstacleSpawner.instance.SpawnObstacle();
    }
}

