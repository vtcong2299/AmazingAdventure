using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : Singleton<SpawnObj>
{
    [SerializeField] ConfigItem[] configItem;
    private void Start()
    {
        ClearListObj();
    }
    public virtual void AddToListObj()
    {
        foreach (ConfigItem item in configItem)
        {
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(item._tag);
            item.ObjList.AddRange(foundObjects);
        }
    }
    public virtual void ClearListObj()
    {
        foreach (ConfigItem item in configItem)
        {
            item.ObjList.Clear();
        }
    }
    public virtual void ResetObj()
    {
        foreach (ConfigItem item in configItem)
        {
            foreach (GameObject child in item.ObjList)
            {
                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
