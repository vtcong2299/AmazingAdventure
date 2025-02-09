using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 oldTranform;
    [SerializeField]
    private float distanceDestroy = 3.0f;
    [SerializeField] 
    private float speedFalling = 1.5f;
    [SerializeField] 
    private float delayFalling = 0.75f;    
    [SerializeField] 
    private bool isFall;
    private void Awake()
    {
        oldTranform = transform.position;
    }
    public void CheckFallingFlatform(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Falling());
        }
    }
    private void Update()
    {
        if (isFall)
        {
            if (Vector3.Distance(transform.position, oldTranform) >= distanceDestroy)
            {
                gameObject.SetActive(false);
                isFall = false;
                transform.position = oldTranform;
            }
            if(PlayerCtrl.Instance.isBackPoint)
            {
                isFall = false;
                transform.position = oldTranform;
            }
            Vector3 posFalling = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, posFalling, speedFalling * Time.deltaTime);
        }
    }
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(delayFalling);
        isFall = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckFallingFlatform(collision);
    }
}
