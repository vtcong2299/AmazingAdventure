using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : SpawnObj
{
    [Header("SpawnBullet")]
    public static SpawnBullet instance;
    [SerializeField]
    private List<GameObject> objPreFab;
    [SerializeField]
    private float spawnTimer = 0f;
    [SerializeField]
    private float spawnDelay = 1f;
    [SerializeField]
    private int maxObj = 4;
    private void Reset()
    {
        preFabName = "BulletPrefab";
        spawnPosTag = "posBullet";
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void UpdateBullet()
    {
        this.Spawn();
        this.CheckDead();
    }
    public override void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < spawnDelay)
        {
            return;
        }
        this.spawnTimer = 0;
        if (this.objPreFab.Count >= this.maxObj)
        {
            return;
        }
        for (index = 0; index < spawnPosObjList.Count; index++)
        {
            GameObject obj = Instantiate(preFab, spawnPosObjList[index].transform.position, Quaternion.identity);
            obj.transform.parent = transform;
            obj.gameObject.SetActive(true);
            this.objPreFab.Add(obj);
            //foreach (int i in SpawnPlan.instance.indexPlan)
            //{
            //    if (index == i)
            //    {
            //        GameObject obj = Instantiate(preFab, spawnPosObjList[index].transform.position, Quaternion.identity);
            //        obj.transform.parent = transform;
            //        obj.gameObject.SetActive(true);
            //        this.objPreFab.Add(obj);
            //    }
            //}            
        }
    }
    public void CheckDead()
    {
        GameObject minion;
        for (int i = 0; i < this.objPreFab.Count; i++)
        {
            minion = this.objPreFab[i];
            if (minion == null)
            {
                this.objPreFab.RemoveAt(i);
            }
        }
    }
}

   
