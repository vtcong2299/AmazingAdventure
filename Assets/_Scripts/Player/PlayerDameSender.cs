using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameSender : DameSender
{
    private PlayerDameReceiver playerDameReceiver;
    PlayerInteract playerInteract;
    private void Awake()
    {
        damage = 1;
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
        playerInteract = GetComponent<PlayerInteract>();
    }
    public override void ColliderSendDame(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Dead")
        {
            base.ColliderSendDame(collision);
            playerDameReceiver.playerAnimatorManager.SetDead();
            playerDameReceiver.Receiver(damage * 3);
        }
        if ((collision.gameObject.tag == "Spike"|| collision.gameObject.tag == "Enemy")&& !playerInteract.hasEnemy)
        {
            AudioManager.Instance.SoundHit();
            playerDameReceiver.playerAnimatorManager.SetHit();
            base.ColliderSendDame(collision);
            playerDameReceiver.Receiver(damage);
            PlayerCtrl.Instance.JumpBack(collision);
        }
        GameManager.Instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
    }
}
