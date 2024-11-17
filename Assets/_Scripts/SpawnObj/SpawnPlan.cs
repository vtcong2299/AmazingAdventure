using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlan : SpawnObj
{
    [Header("SpawnPlan")]
    public static SpawnPlan instance;
    private void Reset()
    {
        spawnPosTag = "posPlan";
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
