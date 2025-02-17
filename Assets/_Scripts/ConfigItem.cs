using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemConfig", menuName = "Config/Item")]
public class ConfigItem : ScriptableObject
{
    public GameObject _prefab;
    public int index = 0;
    public List<GameObject> spawnPosObjList = new List<GameObject>();
    public string _tag;
    public void ResetConfig()
    {
        index = 0;
        spawnPosObjList.Clear();
    }
}
