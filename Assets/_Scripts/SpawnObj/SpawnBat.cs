using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : SpawnObj
{
    [Header("SpawnBat")]
    public static SpawnBat instance;
    private void Reset()
    {
        spawnPosTag = "posBat";
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
