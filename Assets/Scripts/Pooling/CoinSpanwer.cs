using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpanwer : MonoBehaviour
{
    // Start is called before the first frame update
    public static CoinSpanwer instance;

    [SerializeField] private float coinSpawnDistance = 65;
    private CoinSpawnPoint[] coinSpawnPoints;

    private void Awake()
    {
        instance = this;
        coinSpawnPoints = new CoinSpawnPoint[]{
            new CoinSpawnPoint(new Vector3(0, 0.5f, coinSpawnDistance), Quaternion.Euler(90, -90, 90)),
            new CoinSpawnPoint(new Vector3(1.5f, 1.5f, coinSpawnDistance), Quaternion.Euler(150, -90, 90)),
            new CoinSpawnPoint(new Vector3(1.5f, 3.25f, coinSpawnDistance), Quaternion.Euler(210, -90, 90)),
            new CoinSpawnPoint(new Vector3(0, 4.5f, coinSpawnDistance), Quaternion.Euler(270, -90, 90)),
            new CoinSpawnPoint(new Vector3(-1.5f, 3.5f, coinSpawnDistance), Quaternion.Euler(330, -90, 90)),
            new CoinSpawnPoint(new Vector3(-1.5f, 1.75f, coinSpawnDistance), Quaternion.Euler(30, -90, 90))
        };
    }

    public void SpawnCoin()
    {
        CoinSpawnPoint spawn = coinSpawnPoints[Random.Range(0, coinSpawnPoints.Length)];
        ObjectPooler.instance.SpawnFromPool("coin", spawn.position, spawn.rotation);
    }

    struct CoinSpawnPoint
    {
        public Vector3 position;
        public Quaternion rotation;
        public CoinSpawnPoint(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}
