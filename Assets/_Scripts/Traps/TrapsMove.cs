using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMove : MonoBehaviour
{
    public Vector3[] targetPoint;
    [SerializeField]
    protected float speed = 0.5f;
    [SerializeField] 
    private int index=0;
    private void Update()
    {
        TrapMove();
    }
    public virtual void TrapMove()
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
    public virtual void AnimMove(int index) { }
}
