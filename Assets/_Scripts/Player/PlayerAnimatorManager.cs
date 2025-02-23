using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    public Animator animator;
    string animDead = "isDead";
    string animHit = "isHit";
    string animBackCheckPoint = "BackCheckPoint";
    string animFall = "isFall";
    string animInWall = "inWall";
    string animRun = "isRun";
    string animJump = "Jump";
    string animDoubleJump = "DoubleJump";
    string animInGround = "inGround";

    private void OnEnable()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }      
    public void SetHit()
    {
        animator.SetTrigger(animHit);
    }
    public void SetBackCheckPoint()
    {
        animator.SetTrigger(animBackCheckPoint);
    }
    public void SetDead()
    {
        animator.SetTrigger(animDead);
    }
    public void SetFall(bool isFall)
    {
        animator.SetBool(animFall, isFall);
    }
    public void SetInWall(bool inWall)
    {
        animator.SetBool(animInWall, inWall);
    }
    public void SetIsRun(bool isRun)
    {
        animator.SetBool(animRun, isRun);
    }
    public void SetJump()
    {
        animator.SetTrigger(animJump);
    }
    public void SetDoubleJump()
    {
        animator.SetTrigger(animDoubleJump);
    }
    public void SetInGround(bool inGround)
    {
        animator.SetBool(animInGround, inGround);
    }
}


