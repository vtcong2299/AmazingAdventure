using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMove : MonoBehaviour
{
    public Vector3[] targetPoint;
    public float speed = 0.5f;
    public int index=0;
    private void Update()
    {
        TrapMove();
    }
    public void TrapMove()
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
        FlatFormAnimationManager.instance.SetMoveFlB();
        SawAnimationManager.instance.SetMoveSaw();
    }
}
