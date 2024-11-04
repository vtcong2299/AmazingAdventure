using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public Animator animator;
    public static EndPoint instance;
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
    public void SetEnd(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            animator.SetTrigger("End");
        }
    }
}
