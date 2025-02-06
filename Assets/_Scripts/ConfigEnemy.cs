using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyConfig", menuName = "Config/Enemy")]
public class ConfigEnemy : ScriptableObject
{
    public int _id;
    public GameObject _prefab;
    public string _tag;
}
[CreateAssetMenu(fileName = "NewItemConfig", menuName = "Config/Item")]
public class ConfigItem : ScriptableObject
{
    public int _id;
    public GameObject _prefab;
    public string _tag;
}
[CreateAssetMenu(fileName = "NewItemConfig", menuName = "Config/Traps")]
public class ConfigTrap : ScriptableObject
{
    public int _id;
    public GameObject _prefab;
    public string _tag;
}
