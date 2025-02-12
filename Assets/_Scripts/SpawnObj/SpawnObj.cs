using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : Singleton<SpawnObj>
{
    [SerializeField] ConfigItem[] configItem;
    private void Start()
    {
        ResetConfigItems();
    }
    public virtual void AddPosObj()
    {
        foreach (ConfigItem item in configItem)
        {
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(item._tag);
            item.spawnPosObjList.AddRange(foundObjects);
        }
    }
    public virtual void Spawn()
    {
        foreach (ConfigItem item in configItem) 
        {
            for (item.index = 0; item.index < item.spawnPosObjList.Count; item.index++)
            {
                GameObject obj = Instantiate(item._prefab, item.spawnPosObjList[item.index].transform.position, Quaternion.identity);
                obj.transform.parent = transform;
                obj.gameObject.SetActive(true);
            }
        }
    }
    public virtual void DestroyObj()
    {
        foreach (ConfigItem item in configItem)
        {
            item.spawnPosObjList.Clear();
        }
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
        foreach (GameObject child in children)
        {
            Destroy(child);
        }
    }
    public virtual void ResetObj()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
        foreach (GameObject child in children)
        {
            if (!child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void ResetConfigItems()
    {
        foreach (ConfigItem item in configItem)
        {
            item.ResetConfig();
        }
    }
}
