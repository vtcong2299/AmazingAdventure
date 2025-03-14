using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBoxRock : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }    
    public void Top()
    {
        animator.SetTrigger("top");
    }
    public void Bot()
    {
        animator.SetTrigger("bot");
    }
    public void Left()
    {
        animator.SetTrigger("left");
    }
    public void Right()
    {
        animator.SetTrigger("right");
    }
}
