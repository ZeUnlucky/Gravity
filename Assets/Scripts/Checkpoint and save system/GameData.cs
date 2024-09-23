using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public Vector3 PlayerPosition;
    public int Score;
    public List<string> CollectedItems;

    public GameData(Vector3 playerPosition, int score, List<string> collectedItems)  
    {
        PlayerPosition = playerPosition;
        Score = score;
        CollectedItems = collectedItems;
    }
}
