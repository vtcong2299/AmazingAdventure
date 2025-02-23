using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public AnimBat animBat;
    public GameObject targetPoint;
    public Vector3 oldPosition;
    public Vector3 targetPos;
    [SerializeField]
    private float speed = 0.8f;   
    [SerializeField]
    private float distancePlayer = 1.5f;
    private void Awake()
    {
        oldPosition = transform.position;
        targetPoint = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        MoveEnemy();
    }
    public virtual void MoveEnemy()
    {
        if ((Vector3.Distance(transform.position, targetPoint.transform.position) <= distancePlayer)&&(targetPoint.transform.position.y <= transform.position.y))
        {
            targetPos = targetPoint.transform.position;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 target = transform.position + new Vector3(Random.Range(-1f, 1f), 0.7f, 0);
            if (collision.gameObject.GetComponent<PlayerDameReceiver>().hp == 1)
            {
                target = oldPosition;
            }
            transform.DOMove(target, 1f).SetEase(Ease.OutCubic);
        }
    }
}
