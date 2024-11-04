using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAnimationManager : MonoBehaviour
{
    public Animator animator;
    public static SawAnimationManager instance;
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
    public void SetMoveSaw()
    {
        animator.SetBool("MoveSaw", true);
    }
}
