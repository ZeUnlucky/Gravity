using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

public class CustomAnalyticsManager : MonoBehaviour
{
    //trigger this when an item is collected
    public static void TrackItemCollection(string itemType)
    {
        CoinCollectionAnalyticsEvent eventToSend = new CoinCollectionAnalyticsEvent();
        eventToSend.TimeCollected = Time.timeSinceLevelLoad;
        eventToSend.ItemType = "coin";
        AnalyticsService.Instance.RecordEvent(eventToSend);
        Debug.Log ("Item Collected. Event Sent: " + itemType);
    }

    // trigger when checkpoint is passed
    public static void TrackCheckpointPassed(int checkpointNumber)
    {
        Analytics.CustomEvent("checkpoint_passed", new Dictionary<string, object>
        {
            { "checkpoint_number", checkpointNumber },
            { "time_passed", Time.timeSinceLevelLoad }
        });
        Debug.Log("Checkpoint passed event sent: " + checkpointNumber);
    }
}
