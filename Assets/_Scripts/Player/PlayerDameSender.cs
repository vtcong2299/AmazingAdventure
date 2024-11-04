using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameSender : DameSender
{
    public PlayerDameReceiver playerDameReceiver;
    private void Start()
    {
        damage = 1;
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
    }
    public override void ColliderSendDame(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Dead")
        {
            base.ColliderSendDame(collision);
            PlayerAnimatorManager.instance.SetDead();
            playerDameReceiver.Receiver(damage * 3);
        }
        if (collision.gameObject.tag == "Spike"|| collision.gameObject.tag == "Enemy")
        {
            PlayerAnimatorManager.instance.SetHit();
            base.ColliderSendDame(collision);
            playerDameReceiver.Receiver(damage);
            //PlayerMove.instance.HitMove(collision);
        }
        UIManager.instance.HeartUI(playerDameReceiver.hp);
       // GameManager.instance.CheckUiHpPlaying(playerDameReceiver.hp);
    } 
}
