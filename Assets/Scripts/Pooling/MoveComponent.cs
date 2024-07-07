using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float objectDistance = -10f;
    [SerializeField] private float despawnDistance =  -110f;

    private bool canSpawnObject = true;

    void Start()
    {

    }

    void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        if (transform.position.z <= objectDistance && transform.tag == "Obstacle" && canSpawnObject)
        {
            ObstacleSpawner.instance.SpawnObstacle();
            canSpawnObject = false;
        }
        if (transform.position.z <= objectDistance && transform.tag == "Floor" && canSpawnObject)
        {
            FloorSpawner.instance.SpawnFloor();
            canSpawnObject = false;
        }
        if (transform.position.z <= despawnDistance)
        {
            canSpawnObject = true;
            gameObject.SetActive(false);
        }
    }

}
