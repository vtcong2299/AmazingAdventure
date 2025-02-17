using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewConfig", menuName = "Config/Map")]

public class ConfigMap : ScriptableObject
{
    public int _id;
    public string _name;
    public int _targetApple;
    public int _targetBanana;
    public int _targetCherry;
}
    

