using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMushroom : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void MushroomRun(bool state)
    {
        animator.SetBool("isRun", state);
    }
    public void MushroomHit()
    {
        animator.SetTrigger("isHit");
    }
}
