using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CoinCollectionAnalyticsEvent : Unity.Services.Analytics.Event
{
    public CoinCollectionAnalyticsEvent() : base("item_collected")
    {
    }


    public string ItemType { set { SetParameter("item_type", value); } }
    public float TimeCollected { set { SetParameter("time_collected", value); } }
}
