using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int PlayerScore;
    public List<string> CollectedItems;
    public GameObject Player; // Reference to the Player in the scene

    private float saveInterval = 1.0f; // Save every 1 second
    private float timer = 0.0f;

    private void Start()
    {
        // Initial save when the game starts
        SaveGame();

        // Start auto-save functionality every 1 second
        StartCoroutine(AutoSave());
    }

    void SaveGame()
    {
        // Save the current game state
        Vector3 playerPosition = Player.transform.position;
        GameData data = new GameData(playerPosition, PlayerScore, CollectedItems);

        // Save the game with a timestamp
        SaveSystem.SaveGame(data, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Initial Game Save Created");
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(saveInterval); // Wait for the save interval (1 second)

            // Update the save file every 1 second
            Vector3 playerPosition = Player.transform.position;
            GameData data = new GameData(playerPosition, PlayerScore, CollectedItems);

            // Save with a single file (could modify the file name if needed)
            SaveSystem.SaveGame(data, "autosave");
            Debug.Log("Game Updated and Saved Automatically");
        }
    }
}
