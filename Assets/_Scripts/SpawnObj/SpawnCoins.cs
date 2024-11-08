using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : SpawnObj
{
    [Header("SpawnCoins")]
    public static SpawnCoins instance;   
    private void Reset()
    {
        preFabName = "CoinsPrefab";
        spawnPosTag = "posCoins";
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
