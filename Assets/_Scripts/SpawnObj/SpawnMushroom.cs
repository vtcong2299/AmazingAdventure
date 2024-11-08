using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMushroom : SpawnObj
{
    [Header("SpawnMushroom")]
    public static SpawnMushroom instance;
    private void Reset()
    {
        preFabName = "MushroomPrefab";
        spawnPosTag = "posMushroom";
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
