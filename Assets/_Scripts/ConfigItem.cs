using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConfig", menuName = "Config/Item")]
public class ConfigItem : ScriptableObject
{
    public List<GameObject> ObjList = new List<GameObject>();
    public string _tag;
}
