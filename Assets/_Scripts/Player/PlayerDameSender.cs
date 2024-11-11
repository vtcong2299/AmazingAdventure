using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameSender : DameSender
{
    private PlayerDameReceiver playerDameReceiver;
    private PlayerVsItem playerVsItem;
    private void Awake()
    {
        damage = 1;
        playerVsItem = GetComponent<PlayerVsItem>();
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
    }
    public override void ColliderSendDame(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Dead")
        {
            base.ColliderSendDame(collision);
            playerDameReceiver.playerAnimatorManager.SetDead();
            playerDameReceiver.Receiver(damage * 3);
        }
        if (collision.gameObject.tag == "Spike"|| collision.gameObject.tag == "Enemy")
        {
            playerVsItem.audioSource.clip = playerVsItem.hitClip;
            playerVsItem.audioSource.Play();
            playerDameReceiver.playerAnimatorManager.SetHit();
            base.ColliderSendDame(collision);
            playerDameReceiver.Receiver(damage);
            PlayerMove.instance.JumpBackAfterHit(collision);
        }
        GameManager.instance.ManagerHeartUI(playerDameReceiver.hp);
    }
}
