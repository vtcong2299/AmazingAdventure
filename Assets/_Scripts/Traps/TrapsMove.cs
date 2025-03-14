using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMove : MonoBehaviour
{
    [SerializeField] Vector3 target;
    [SerializeField] float time = 10;
    private void Awake()
    {
        TrapMove();
    }
    public virtual void TrapMove()
    {
        transform.DOLocalMove(target, time)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
