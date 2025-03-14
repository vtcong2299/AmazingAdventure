using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBat : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void SetCell(bool state)
    {
        animator.SetBool("cellOut", state);
    }
    public void BatHit()
    {
        animator.SetTrigger("isHit");
    }   
}
