using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public static EndPoint instance;
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        instance = this;
    }    
    public void SetEnd(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            animator.SetTrigger("End");
        }
    }
}
