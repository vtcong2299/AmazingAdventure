using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BoxRockMove : MonoBehaviour
{
    public Vector3[] targetPoint;
    [SerializeField]
    protected float speed = 0.5f;
    [SerializeField]
    private int index = 0;

    public AnimBoxRock animBoxRock;
    private void Awake()
    {
        targetPoint = new Vector3[4];
        speed = 5f;
        targetPoint[0] = new Vector3(transform.position.x, transform.position.y+ 2.03f, transform.position.z);
        targetPoint[1] = new Vector3(transform.position.x + 3.37f, transform.position.y +2.03f, transform.position.z);
        targetPoint[2] = new Vector3(transform.position.x + 3.37f, transform.position.y, transform.position.z);
        targetPoint[3] = new Vector3(transform.position.x , transform.position.y, transform.position.z);
        animBoxRock = GetComponent<AnimBoxRock>();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 targetPos = targetPoint[index];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPos);
        if (distance <= 0.02f)
        {
            AnimMove(index);
            index++;
        }
        if (index == targetPoint.Length)
        {
            index = 0;
        }
    }
    public void AnimMove(int index)
    {
        switch (index)
        {
            case 0:
                animBoxRock.Top();
                break;
            case 1:
                animBoxRock.Right();
                break;
            case 2:
                animBoxRock.Bot();
                break;
            case 3:
                animBoxRock.Left();
                break;
        }
    }
}
