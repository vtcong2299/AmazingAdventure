using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdMove : EnemyMove
{
    private void Awake()
    {
        targetPoint = new Vector3[2];
        SpeedEnemy();
        targetPoint[0] = new Vector3(transform.position.x - 1.2f, transform.position.y, transform.position.z);
        targetPoint[1] = new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z);
    }
    public override void EnemyCheckGround()
    {
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -transform.right, lengthRaycast, layerWall);
        if (hit2.collider)
        {
            index++;
        }
    }
}

