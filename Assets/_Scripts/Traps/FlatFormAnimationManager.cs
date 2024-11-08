using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFormAnimationManager : MonoBehaviour
{
    public static FlatFormAnimationManager instance;
    private Animator animator;
    private void Awake()
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
    public void SetMoveFlB()
    {
        animator.SetBool("MoveFlB",true);
    }
}
