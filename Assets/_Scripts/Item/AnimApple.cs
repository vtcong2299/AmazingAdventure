using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimApple : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimHit()
    {
        animator.SetTrigger("isHit");
    }
}
