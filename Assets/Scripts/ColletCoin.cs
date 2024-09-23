using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;

public class ColletCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Coin")
        {
            CustomAnalyticsManager.TrackItemCollection("coin");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
