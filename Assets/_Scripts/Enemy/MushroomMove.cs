using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MushroomMove : MonoBehaviour
{
    public Vector3[] targetPoint;
    public float speed = 0.5f;
    public int index = 0;
    public bool enemyFacingRight;
    private void Start()
    {
        StartCoroutine(ExampleCoroutine());
        AnimationMushroom.instance.MushroomRun();
    }        
    private void Update()
    {
        MushMove();
    }    
    public void MushMove()
    {
        Vector3 targetPos = targetPoint[index];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPos);
        if (distance <= 0.02f)
        {
            index++;
        }
        if (index == targetPoint.Length)
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

IEnumerator ExampleCoroutine()
{
        while (true)
        {
            yield return new WaitForSeconds(6f);
            speed = 0;
            AnimationMushroom.instance.MushroomNotRun();
            yield return new WaitForSeconds(4f);
            speed = 0.5f;
            AnimationMushroom.instance.MushroomRun();
        }
}
public void CheckEnemyFacing(Vector3 targetPos)
    {
        Vector3 enemyPos = targetPos- transform.position ;
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
    public void EnemyFlip()
    {
        Vector3 curDirection = transform.right;
        curDirection = -1 * curDirection;
        transform.right = curDirection;
        enemyFacingRight = !enemyFacingRight;
    }
}
