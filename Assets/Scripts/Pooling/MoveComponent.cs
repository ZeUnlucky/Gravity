using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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
        transform.position += -Vector3.forward * speed * Time.deltaTime;

        if (transform.position.z <= objectDistance && canSpawnObject)
        {
            switch (transform.tag)
            {
                case "ObstacleSection":
                    ObstacleSectionSpawner.instance.SpawnObstacleSection();
                    break;
                case "Floor":
                    FloorSpawner.instance.SpawnFloor();
                    break;
                case "Coin":
                    CoinSpanwer.instance.SpawnCoin();
                    break;
            }          
            canSpawnObject = false;
        }
        if (transform.position.z <= despawnDistance)
        {
            canSpawnObject = true;
            gameObject.SetActive(false);
        }
    }


}
