using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string type;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler instance;


    private void Awake()
    {
        instance = this;
    }


    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    GameObject objectToSpawn;

    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.type, objectPool);

        }
    }


    public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(type))
        {
            Debug.LogWarning("Pool with type " + type + " doesnt exist.");
            return null;
        }

        objectToSpawn = PoolDictionary[type].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        PoolDictionary[type].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}