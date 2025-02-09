using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemConfig", menuName = "Config/Item")]
public class ConfigItem : ScriptableObject
{
    public int _id;
    public GameObject _prefab;
    public int index = 0;
    public List<GameObject> spawnPosObjList = new List<GameObject>();
    public string _tag;

    // Phương thức để reset các giá trị của ConfigItem
    public void ResetConfig()
    {
        index = 0;
        spawnPosObjList.Clear();
    }
}
