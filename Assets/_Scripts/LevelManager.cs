using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    int curID;
    int maxLevel = 2;
    [SerializeField] ConfigMap[] configMap;
    [SerializeField] GameObject currentMap;
    [SerializeField] GameObject waitMap;
    public void SelectLevel(int idMap)
    {
        foreach (ConfigMap map in configMap)
        {
            if (map._id == idMap)
            {
                curID = map._id;
                waitMap = Resources.Load<GameObject>(map._name);
                break;
            }
            else
            {
                waitMap = null;
            }
        }
        if (currentMap != null)
        {
            Destroy(currentMap);
            Resources.UnloadUnusedAssets();
        }
        if (waitMap == null)
        {
            return;
        }
        currentMap = Instantiate(waitMap, transform.position, transform.rotation);

    } 
    public void NextLevel()
    {
        curID++;
        if (curID > maxLevel)
        {
            curID = 1;
        }
        GameManager.Instance.SelectLevel(curID);
    }
}
