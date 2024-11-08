using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : SpawnObj
{
    [Header("SpawnStars")]
    public static SpawnStars instance;
    private void Reset()
    {
        preFabName = "StarsPrefab";
        spawnPosTag = "posStars";
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
