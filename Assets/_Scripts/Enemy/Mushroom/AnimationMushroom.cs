using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMushroom : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    //public void MushroomRun()
    //{
    //    animator.SetBool("isRun", true);
    //}
    //public void MushroomNotRun()
    //{
    //    animator.SetBool("isRun", false);
    //}
    public void MushroomHit()
    {
        animator.SetTrigger("isHit");
    }
}
