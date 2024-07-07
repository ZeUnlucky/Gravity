using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;

    [SerializeField] private float obstacleSpawnDistance = 26f;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnObstacle()
    {
        ObjectPooler.instance.SpawnFromPool("obstacle", new Vector3(0, 0.5f, obstacleSpawnDistance), Quaternion.identity);
    }
}
