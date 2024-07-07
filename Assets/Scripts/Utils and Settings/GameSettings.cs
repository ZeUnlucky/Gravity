using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public float PlatformSpeed = 5f;
    public float PlayerMovementSpeed = 10f;
    public float JumpForce = 10f;
    public float SpawnerZ = 22f;
    public float EndZ = -1f;
    public float DefaultPlayerZ = 2f;
}
