using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public static FloorSpawner instance;

    [SerializeField] private float floorSpawnDistance = 26f;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnFloor()
    {
        ObjectPooler.instance.SpawnFromPool("floor", new Vector3(0, 0, floorSpawnDistance), Quaternion.identity);
    }
}
