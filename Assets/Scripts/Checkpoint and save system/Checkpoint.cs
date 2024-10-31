using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int PlayerScore;
    public List<string> CollectedItems;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition= other.transform.position;
            GameData data= new GameData(playerPosition, PlayerScore, CollectedItems);
            SaveSystem.SaveGame(data, DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));  // Save with timestamp
            Debug.Log("Game Saved at checkpoint");
        }
    }
}
