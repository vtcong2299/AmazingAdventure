using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : Singleton<StartPoint>
{
    private Animator animator;
    protected override void Awake()
    {
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
    }
    public void SetPushIn(Collision2D collision)
    {
        if(collision.gameObject.tag=="Start")
        {
            animator.SetTrigger("pushIn");
            PlayerCtrl.Instance.isBackPoint = true;            
        }
    }
    public void SetPushOut(Collision2D collision)
    {
        if(collision.gameObject.tag=="Start")
        {            
            PlayerCtrl.Instance.SetIsBackPointFalse();            
        }
    }
    
}
