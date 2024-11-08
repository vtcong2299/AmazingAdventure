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
    public void CellOut()
    {
        animator.SetBool("cellOut",true);
    }
    public void CellIn()
    {
        animator.SetBool("cellOut",false);
    }
    public void BatHit()
    {
        animator.SetTrigger("isHit");
    }   
}
