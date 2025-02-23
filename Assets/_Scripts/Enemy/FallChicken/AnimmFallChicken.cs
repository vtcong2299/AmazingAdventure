using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimmFallChicken : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void Fall()
    {
        animator.SetTrigger("isFall");
    }
    public void Ground()
    {
        animator.SetTrigger("isGround");
    }
    public void Hit()
    {
        animator.SetTrigger("isHit");
    }
}
