using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBlueBird : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }    
    public void BlueBirdHit()
    {
        animator.SetTrigger("isHit");
    }
}
