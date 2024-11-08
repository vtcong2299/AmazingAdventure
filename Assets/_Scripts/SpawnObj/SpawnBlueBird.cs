using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlueBird : SpawnObj
{
    [Header("SpawnBlueBird")]
    public static SpawnBlueBird instance;
    private void Reset()
    {
        preFabName = "BlueBirdPrefab";
        spawnPosTag = "posBlueBird";
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
}
