using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxRock : SpawnObj
{
    [Header("SpawnBoxRock")]
    public static SpawnBoxRock instance;
    private void Reset()
    {
        preFabName = "BoxRockPrefab";
        spawnPosTag = "posBoxRock";
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
