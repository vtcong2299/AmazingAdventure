using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public static StartPoint instance;
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        instance = this;
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
