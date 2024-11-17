using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : SpawnObj
{
    [Header("SpawnHeart")]
    public static SpawnHeart instance;
    private void Reset()
    {
        spawnPosTag = "posHeart";
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
