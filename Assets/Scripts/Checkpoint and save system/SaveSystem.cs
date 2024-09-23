using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(GameData data, string fileName)
    {
        string savePath = Application.persistentDataPath + "/" + fileName + ".dat";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public static GameData LoadGame(string savePath)
    {
        if (File.Exists(savePath))
        {
           string json = File.ReadAllText(savePath);
            GameData data= JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game Loaded from: " + savePath);
            return data;
        }

        else
        {
            Debug.LogWarning("No save file found at " + savePath);
            return null;
        }
    }
}
