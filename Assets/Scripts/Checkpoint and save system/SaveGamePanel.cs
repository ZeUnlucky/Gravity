using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveGamePanel : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public Transform ContentPanel;

    private string savePath;

    private void Start()
    {
        savePath = Application.persistentDataPath;
        LoadSavedGames();
    }

    void LoadSavedGames()
    {
        foreach (Transform child in ContentPanel)
        {
            Destroy(child.gameObject);
        }

        DirectoryInfo dir = new DirectoryInfo(savePath);
        FileInfo[] files = dir.GetFiles("*.dat");
        foreach (FileInfo file in files)
        {
            GameObject button = Instantiate(ButtonPrefab, ContentPanel);
            button.GetComponentInChildren<Text>().text = file.Name;
            Button btn = button.GetComponent<Button>();
            string FilePath = file.FullName;
            btn.onClick.AddListener(() => LoadSelectedGame(FilePath));
        }
    }

    void LoadSelectedGame(string filePath)
    {
        GameData data = SaveSystem.LoadGame(filePath);

        if (data != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = data.PlayerPosition;
            Debug.Log("Loaded game from " + filePath);
        }
        else
        {
            Debug.LogWarning("Failed to load game data");
        }
    }
}
