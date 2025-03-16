using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMove : MonoBehaviour
{
    public Vector3 oldPosition;
    public float speedBullet = 1f;
    float rangeAttack = 4.2f;
    private Transform parentTransform;

    private void Awake()
    {
        oldPosition = transform.position;
    }
    private void OnEnable()
    {
        parentTransform = transform.parent;
    }

    private void Update()
    {
        MoveBullet();
        ResetBullet();
    }

    private void ResetBullet()
    {
        if (Vector3.Distance(oldPosition, transform.position) >= rangeAttack)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall"
            || collision.gameObject.tag == "Black"|| collision.gameObject.tag == "LimitMap" )
        {
            Destroy(gameObject);
        }
    }

    public void MoveBullet()
    {
        if (parentTransform != null)
        {
            transform.position -= parentTransform.right * Time.deltaTime * speedBullet;
        }
    }
}
