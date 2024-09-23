using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfileTest : MonoBehaviour
{
    void Start()
    {
        // Create a new profile
        PlayerProfile newProfile = new PlayerProfile("John Doe", 25, "/path/to/photo.png");

        // Save the profile
        PlayerProfileManager.SaveProfile(newProfile);

        // Load the profile
        PlayerProfile loadedProfile = PlayerProfileManager.LoadProfile();

        if (loadedProfile != null)
        {
            Debug.Log("Player Name: " + loadedProfile.PlayerName);
            Debug.Log("Age: " + loadedProfile.age);
            Debug.Log("Photo Path: " + loadedProfile.PhotoPath);
        }
    }
}