using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass : MonoBehaviour 
{
    [Header("Side Pieces")]
    public GameObject LeftTile;
    public GameObject RightTile;

    public GameObject GetTile(float side)
    {
        if (side > 0)
            return RightTile;
        else if (side < 0)
            return LeftTile;
        else
            return this.gameObject;
    }
}
