using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DameReceiver
{
    public PlayerAnimatorManager playerAnimatorManager;
    void Awake()
    {
        hp = 3;
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }
    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {
            playerAnimatorManager.SetDead();
            playerAnimatorManager.SetBackCheckPoint();
            PlayerMove.instance.BackCheckPoint();
            hp = 3;
        }
    }   
}

