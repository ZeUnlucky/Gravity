using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public GameObject Player;
    public int PlayerScore;
    public List<string> CollectedItems;

    public void LoadGame(string savePath)
    {
        GameData data = SaveSystem.LoadGame(savePath);

        if (data != null)
        {
            Player.transform.position = data.PlayerPosition;
            PlayerScore = data.Score;
            CollectedItems = new List<string>(data.CollectedItems);

            Debug.Log("Game Loaded from last checkpoint");
        }

        else
        {
            Debug.LogWarning("Failed to load game");
        }
    }
}
