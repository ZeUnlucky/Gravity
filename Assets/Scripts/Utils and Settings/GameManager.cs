using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameSettings gameSettings;

    public float PlayerSpeed
    {
        get { return gameSettings.PlayerMovementSpeed; }
    }
    public float JumpForce
    {
        get { return gameSettings.JumpForce; }
    }
    public float PlatformSpeed
    {
        get { return gameSettings.PlatformSpeed; }
    }
    public float SpawnerZ
    {
        get { return gameSettings.SpawnerZ; }
    }
    public float EndZ
    {
        get { return gameSettings.EndZ; }
    }
    public float DefaultPlayerZ
    {
        get { return gameSettings.DefaultPlayerZ; }
    }
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
    }

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManager");
                    instance = singleton.AddComponent<GameManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }

    }
}

