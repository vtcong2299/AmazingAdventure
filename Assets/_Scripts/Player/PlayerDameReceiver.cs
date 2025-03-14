using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DameReceiver
{
    public PlayerAnimatorManager playerAnimatorManager;
    public PlayerInteract playerInteract;
    void Awake()
    {
        hp = 3;
        playerInteract = GetComponent<PlayerInteract>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }
    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {
            PlayerCtrl.Instance.isDead = true;
            AudioManager.Instance.SoundDead();
            playerAnimatorManager.SetDead();            
            PlayerCtrl.Instance.BackCheckPoint();
            hp = 3;
        }
    }   
}

