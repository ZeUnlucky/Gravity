using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollideChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            GameObject canvas = GameObject.Find("Canvas");
            Instantiate(UI, canvas.transform);

        }
    }
}
