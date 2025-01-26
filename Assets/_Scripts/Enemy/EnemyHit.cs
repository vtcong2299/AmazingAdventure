using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "FootPlayer"))
        {
            AnimHit();
            PlayerMove.Instance.JumpBackHitEnemy(collision);
            StartCoroutine(DeleyDestroy());
        }
    }
    public virtual void AnimHit(){}
    IEnumerator DeleyDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);        
    }
}
