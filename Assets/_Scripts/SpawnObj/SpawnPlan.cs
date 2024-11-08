using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlan : SpawnObj
{
    [Header("SpawnPlan")]
    public static SpawnPlan instance;
    public bool hasChild;
    public List<GameObject> children = new List<GameObject>();
    public List<int> indexPlan = new List<int>();
    private void Reset()
    {
        preFabName = "PlanPrefab";
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
    private void Update()
    {
        CheckChild();        
    }
    public void CheckChild()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                hasChild = true;
                return;
            }               
        }
        hasChild = false;
    }    
}
