using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMushroom : MonoBehaviour
{
    public Animator animator;
    public static AnimationMushroom instance;
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
    public void MushroomRun()
    {
        animator.SetBool("isRun", true);
    }
    public void MushroomNotRun()
    {
        animator.SetBool("isRun", false);
    }
    public void MushroomHit()
    {
        animator.SetTrigger("isHit");
    }
}
