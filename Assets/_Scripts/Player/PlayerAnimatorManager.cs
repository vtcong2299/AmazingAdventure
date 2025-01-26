using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField] 
    private void Awake()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        animator.SetBool("Dead", false);
    }      
    public void SetHit()
    {
        animator.SetTrigger("isHit");
    }
    public void SetBackCheckPoint()
    {
        animator.SetTrigger("BackCheckPoint");
    }
    public void SetFall()
    {
        animator.SetBool("isFall",true);
    }
    public void SetNotFall()
    {
        animator.SetBool("isFall",false);
    }
    public void SetDead()
    {
        animator.SetBool("Dead",true);
    }
    public void SetNotDead()
    {
        animator.SetBool("Dead",false);
    }    
    public void SetWallJump()
    {
        animator.SetBool("WallJump",true);
    }
    public void SetNotWallJump()
    {
        animator.SetBool("WallJump",false);
    }
    public void SetInWall(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            animator.SetBool("inWall", true);
        }
    }
    public void SetNotInWall(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            animator.SetBool("inWall", false);
        }
    }
    public void SetIsRun()
    {
        animator.SetBool("isRun", true);
    }
    public void SetNotRun()
    {
        animator.SetBool("isRun", false);
    }
    public void SetJump()
    {
        animator.SetTrigger("Jump");
    }
    public void SetDoubleJump()
    {
        animator.SetTrigger("DoubleJump");
    }
    public void SetInGround(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Start" || collision.gameObject.tag == "Flatform")
        {
            animator.SetBool("inGround", true);
        }
    }
    public void SetNotInGround(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Start" || collision.gameObject.tag == "Flatform")
        {
            animator.SetBool("inGround", false);
        }
    }
}


