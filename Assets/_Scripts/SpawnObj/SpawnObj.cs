using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [Header("SpawnObj")]
    protected GameObject preFab;
    protected int index = 0;
    protected List<GameObject> spawnPosObjList = new List<GameObject>();
    [SerializeField]
    protected string preFabName;
    [SerializeField]
    protected string spawnPosTag;
    private void Awake()
    {
        this.preFab = GameObject.Find(preFabName);
        this.preFab.SetActive(false);
    }
    public virtual void AddPosObj()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(spawnPosTag);
        spawnPosObjList.AddRange(foundObjects);
    }
    public virtual void Spawn()
    {
        for (index = 0; index < spawnPosObjList.Count; index++)
        {
            GameObject obj = Instantiate(preFab, spawnPosObjList[index].transform.position, Quaternion.identity);
            obj.transform.parent = transform;
            obj.gameObject.SetActive(true);
        }
    }
    public virtual void DestroyObj()
    {
        spawnPosObjList.Clear();
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
}
