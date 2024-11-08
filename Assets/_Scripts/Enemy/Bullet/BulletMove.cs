using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speedBullet = 1f;
    private Vector3 targetBullet;
    private void Awake()
    {
        targetBullet = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
    }
    private void FixedUpdate()
    {
        this.UpdateSpeed();
    }
    protected virtual void UpdateSpeed()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetBullet, speedBullet * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, targetBullet) <= 0.1f)
        {
            this.DesSpawnBullet();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckDestroy(collision);
    }
    private void CheckDestroy(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "PlayerBody")
        {
            DesSpawnBullet();
        }
    }
    protected virtual void DesSpawnBullet()
    {
        Destroy(gameObject);
    }
}
