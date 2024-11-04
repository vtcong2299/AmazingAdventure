using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DameReceiver
{    
    void Start()
    {
        hp = 3;
    }
    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {
            PlayerAnimatorManager.instance.SetDead();
            PlayerAnimatorManager.instance.SetBackCheckPoint();
            PlayerMove.instance.BackCheckPoint();
            hp = 3;
        }
    }   
}

