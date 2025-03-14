using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : Singleton<EndPoint>
{
    private Animator animator;
    protected override void Awake()
    {
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
    }
    public void SetEnd(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            animator.SetTrigger("End");
        }
    }
}
