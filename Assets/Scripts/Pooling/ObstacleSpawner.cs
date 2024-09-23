using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;

    [SerializeField] private float obstacleSpawnDistance = 26f;
    private ObstacleSpawnPoint[] obstacleSpawnPoints;

    private void Awake()
    {
        instance = this;
        obstacleSpawnPoints = new ObstacleSpawnPoint[]{ 
            new ObstacleSpawnPoint(new Vector3(0, 0.5f, obstacleSpawnDistance), 0),
            new ObstacleSpawnPoint(new Vector3(1.5f, 1.5f, obstacleSpawnDistance), 60),
            new ObstacleSpawnPoint(new Vector3(1.5f, 3.25f, obstacleSpawnDistance), 120),
            new ObstacleSpawnPoint(new Vector3(0, 4.5f, obstacleSpawnDistance), 180),
            new ObstacleSpawnPoint(new Vector3(-1.5f, 3.5f, obstacleSpawnDistance), 240),
            new ObstacleSpawnPoint(new Vector3(-1.5f, 1.75f, obstacleSpawnDistance), 300)
        };
    }

    public void SpawnObstacle()
    {
        int[] lastNumbers = { -1, -1, -1, -1, -1,};
        int obstaclesToSpawn = Random.Range(1, 4);
        if (Time.timeSinceLevelLoad > 60 && Time.timeSinceLevelLoad < 120)
            obstaclesToSpawn = Random.Range(2, 5);
        else if (Time.timeSinceLevelLoad > 120)
            obstaclesToSpawn = Random.Range(3, 5);
        Debug.Log(obstaclesToSpawn);
        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            int rng = Random.Range(0, obstacleSpawnPoints.Length);
            while (lastNumbers.Contains(rng)) rng = Random.Range(0, obstacleSpawnPoints.Length);
            lastNumbers[i] = rng;

            ObstacleSpawnPoint spawn = obstacleSpawnPoints[rng];
            ObjectPooler.instance.SpawnFromPool("obstacle", spawn.position, Quaternion.Euler(0, 0, spawn.rotation));
        }
    }
}

struct ObstacleSpawnPoint
{
    public Vector3 position;
    public float rotation;
    public ObstacleSpawnPoint(Vector3 position, float rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}
