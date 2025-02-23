using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{    
    public GameObject preFab;
    public float spawnTimer = 0f;
    float spawnDelay = 0.99f;
    [SerializeField] Vector3 offset;
    private void Awake()
    {
        this.preFab.SetActive(false);
    }
    private void OnEnable()
    {
        offset = new Vector3(transform.right.x / 8, 0.03f, 0);
    }
    void Update()
    {
        this.Spawn();
    }   
    protected virtual void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < spawnDelay)
        {
            return;
        }
        this.spawnTimer = 0;
        GameObject obj = Instantiate(this.preFab);
        obj.transform.position = new Vector3(transform.position.x - offset.x, transform.position.y + offset.y, transform.position.z);
        obj.transform.parent = transform;
        obj.gameObject.SetActive(true);
    }
}


