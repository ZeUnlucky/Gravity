using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileUIManager : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;

    private void Start()
    {
        saveButton.onClick.AddListener(SavePlayerProfile);
        loadButton.onClick.AddListener(LoadPlayerProfile);
    }

    void SavePlayerProfile()
    {
        PlayerProfile newProfile = new PlayerProfile("John Doe", 25, "/path/to/photo.png");
        PlayerProfileManager.SaveProfile(newProfile);
    }

    void LoadPlayerProfile()
    {
        PlayerProfile loadedProfile = PlayerProfileManager.LoadProfile();
        if (loadedProfile != null)
        {
            Debug.Log("Player Name: " + loadedProfile.PlayerName);
            Debug.Log("Age: " + loadedProfile.age);
            Debug.Log("Photo Path: " + loadedProfile.PhotoPath);
        }
    }
}
