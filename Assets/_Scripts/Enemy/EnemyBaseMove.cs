using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseMove : MonoBehaviour
{
    public Vector3[] targetPoint;
    [SerializeField] protected float speed = 0.5f;
    [SerializeField] protected int index = 0;
    public bool enemyFacingRight;
    [SerializeField] protected LayerMask layerGround;
    [SerializeField] protected LayerMask layerWall;
    [SerializeField] protected float lengthRaycast = 0.3f;
    [SerializeField] protected Vector3 offset = new Vector3(1.2f, 0, 0);

    private void Update()
    {
        MoveEnemy();
    }
    public virtual void MoveEnemy()
    {
        Vector3 targetPos = targetPoint[index];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPos);
        EnemyCheckGround();
        if (distance <= 0.02f)
        {
            index++;
        }
        if (index >= targetPoint.Length)
        {
            index = 0;
        }
        CheckEnemyFacing(targetPos);
        if (index == 0 && enemyFacingRight)
        {
            EnemyFlip();
        }
        if (index == 1 && !enemyFacingRight)
        {
            EnemyFlip();
        }
    }
    public virtual void SpeedEnemy()
    {
        speed = Random.Range(0.3f, 0.55f);
    }
    public virtual void CheckEnemyFacing(Vector3 targetPos)
    {
        Vector3 enemyPos = targetPos - transform.position;
        float angle = Vector3.Angle(Vector3.right, enemyPos);
        if (angle == 0)
        {
            enemyFacingRight = true;
        }
        else
        {
            enemyFacingRight = false;
        }
    }
    public virtual void EnemyFlip()
    {
        Vector3 curDirection = transform.right;
        curDirection = -1 * curDirection;
        transform.right = curDirection;
        enemyFacingRight = !enemyFacingRight;
    }
    public virtual void EnemyCheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, lengthRaycast, layerGround);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -transform.right, lengthRaycast, layerWall);
        if (!hit.collider || hit2.collider)
        {
            index++;
        }
    }
}
