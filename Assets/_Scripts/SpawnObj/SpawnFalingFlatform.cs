using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFalingFlatform : SpawnObj
{
    [Header("SpawnFalingFlatform")]
    public static SpawnFalingFlatform instance;
    private void Reset()
    {
        spawnPosTag = "posFallingFlatform";
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public override void ResetObj()
    {
        DestroyObj();
        AddPosObj();
        Spawn();
    }
}
