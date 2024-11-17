using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{    
    public List<GameObject> objPreFab;
    public GameObject preFab;
    public float spawnTimer = 0f;
    public float spawnDelay = 1f;
    public int maxObj = 2;
    public int index = 0;
    private void Awake()
    {
        this.preFab.SetActive(false);
        this.objPreFab = new List<GameObject>();
    }
    void Update()
    {
        this.Spawn();
        this.CheckDead();
    }   
    protected virtual void Spawn()
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
        GameObject obj = Instantiate(this.preFab);
        obj.name = "Bullet " + index;
        index++;
        if (index >= this.maxObj)
        {
            index = 0;
        }
        obj.transform.position = new Vector3(transform.position.x - 0.12f, transform.position.y + 0.028f, transform.position.z);
        obj.transform.parent = transform;
        obj.gameObject.SetActive(true);
        objPreFab.Add(obj);
    }
    protected virtual void CheckDead()
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


