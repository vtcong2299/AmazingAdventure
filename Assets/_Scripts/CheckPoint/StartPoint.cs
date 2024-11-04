using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public Animator animator;
    public static StartPoint instance;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void SetPushIn(Collision2D collision)
    {
        if(collision.gameObject.tag=="Start")
        {
            animator.SetTrigger("pushIn");
        }
    }
}
