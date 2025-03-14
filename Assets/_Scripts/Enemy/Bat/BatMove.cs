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
    [SerializeField] float speed = 0.8f;   
    [SerializeField] float distancePlayer = 1.5f;
    public bool enemyFacingRight;
    private void Awake()
    {
        oldPosition = transform.position;
    }
    private void Start()
    {
        targetPoint = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        MoveEnemy();
    }
    public virtual void MoveEnemy()
    {
        float distance = Vector3.Distance(transform.position, targetPoint.transform.position);
        if ((distance <= distancePlayer)&&(targetPoint.transform.position.y <= transform.position.y))
        {
            targetPos = targetPoint.transform.position;
            animBat.SetCell(true);
        }
        else
        {
            targetPos = oldPosition;            
            if((Vector3.Distance(transform.position, oldPosition) == 0f))
            {
                animBat.SetCell(false);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);        
        //CheckEnemyFacing(targetPos);
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
    //public virtual void CheckEnemyFacing(Vector3 targetPos)
    //{
    //    Vector3 enemyPos = targetPos - transform.position;
    //    float angle = Vector3.Angle(Vector3.right, enemyPos);
    //    if (angle == 0)
    //    {
    //        enemyFacingRight = true;
    //        EnemyFlip(-1);
    //    }
    //    else
    //    {
    //        enemyFacingRight = false;
    //        EnemyFlip(1);
    //    }
    //}
    //public virtual void EnemyFlip(float scale)
    //{
    //    transform.localScale = new Vector3(scale , 1, 1);
    //}
}
