using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "FootPlayer"))
        {
            AnimationMushroom.instance.MushroomHit();
            PlayerMove.instance.HitMoveEnemy(collision);
            StartCoroutine(DeleyDestroy());
        }
    }
    IEnumerator DeleyDestroy()
    {
        yield return new WaitForSeconds(0.15f);
        gameObject.SetActive(false);
    }    
}
