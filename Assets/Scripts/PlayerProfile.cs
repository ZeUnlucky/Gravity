using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class PlayerProfile
{
    public string PlayerName;
    public int age;
    public string PhotoPath;


    public PlayerProfile(string playerName, int age, string photoPath)
    {
        PlayerName = playerName;
        this.age = age;
        PhotoPath = photoPath;
    }
}

public static class PlayerProfileManager
{
    private static string FilePath = Path.Combine(Application.persistentDataPath, "playerprofile.json");

    public static void SaveProfile(PlayerProfile profile)
    {
        try
        {
            string json = JsonUtility.ToJson(profile);
            File.WriteAllText(FilePath, json);
            Debug.Log("Profile saved to " + FilePath);
        }

        catch (Exception e)
        {
            Debug.LogError("Failed to save profile: " + e.Message);
        }
    }

    public static PlayerProfile LoadProfile()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                PlayerProfile profile = JsonUtility.FromJson<PlayerProfile>(json);
                Debug.Log("Profile loaded from " + FilePath);
                return profile;
            }
            else
            {
                Debug.LogWarning("Profile file not found");
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to load profile: " + e.Message);
            return null;
        }
    }
}