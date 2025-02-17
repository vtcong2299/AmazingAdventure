using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") && PlayerCtrl.Instance.playerInteract.hasEnemy)
        {
            AnimHit();
            PlayerCtrl.Instance.JumpBack(collision);
            Invoke("DestroyEnemy", 0.25f);
        }
    }
    public virtual void AnimHit(){}
    void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }   
}
