using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlan : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void PlanHit()
    {
        animator.SetTrigger("isHit");
    }
}
