using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DameReceiver
{
    public PlayerAnimatorManager playerAnimatorManager;
    public PlayerVsItem playerVsItem;
    void Awake()
    {
        hp = 3;
        playerVsItem = GetComponent<PlayerVsItem>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }
    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {
            playerVsItem.audioSource.clip = playerVsItem.deadClip;
            playerVsItem.audioSource.Play();
            playerAnimatorManager.SetDead();
            playerAnimatorManager.SetBackCheckPoint();
            PlayerMove.instance.BackCheckPoint();
            hp = 3;
        }
    }   
}

