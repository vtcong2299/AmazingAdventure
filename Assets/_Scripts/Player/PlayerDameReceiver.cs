using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DameReceiver
{
    public PlayerAnimatorManager playerAnimatorManager;
    public PlayerInteract playerVsItem;
    void Awake()
    {
        hp = 3;
        playerVsItem = GetComponent<PlayerInteract>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }
    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {
            AudioManager.Instance.SoundDead();
            playerAnimatorManager.SetDead();            
            PlayerCtrl.Instance.BackCheckPoint();
            hp = 3;
        }
    }   
}

