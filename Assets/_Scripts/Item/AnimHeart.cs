using UnityEngine;

public class AnimHeart : MonoBehaviour
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
