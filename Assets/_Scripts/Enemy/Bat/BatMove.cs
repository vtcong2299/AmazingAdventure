using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public AnimBat animBat;
    public Transform targetPoint;
    public Vector3 oldPosition;
    public Vector3 targetPos;
    [SerializeField]
    private float speed = 0.8f;   
    [SerializeField]
    private float distancePlayer = 1.5f;
    private void Awake()
    {
        oldPosition = transform.position;
        animBat = GetComponent<AnimBat>();
    }
    private void Update()
    {
        MoveEnemy();
    }
    public virtual void MoveEnemy()
    {
        if ((Vector3.Distance(transform.position, targetPoint.position) <= distancePlayer)&&(targetPoint.position.y <= transform.position.y))
        {
            targetPos = targetPoint.position;
            animBat.CellOut();
        }
        else
        {
            targetPos = oldPosition;            
            if((Vector3.Distance(transform.position, oldPosition) == 0f))
            {
                animBat.CellIn();
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPos);
    }
}
