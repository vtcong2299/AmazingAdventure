using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChickenMove : MonoBehaviour
{
    [SerializeField] float lengRaycast = 3;
    [SerializeField] float oldPos;
    [SerializeField] float time1 = 1;
    [SerializeField] float time2 = 5;
    [SerializeField] LayerMask layerPlayer;    
    [SerializeField] SpriteRenderer spriteRenderer;
    private AnimmFallChicken animmFallChicken;
    private void Awake()
    {
        animmFallChicken = GetComponent<AnimmFallChicken>();
    }
    private void Start()
    {
        oldPos = transform.localPosition.y;
    }
    private void Update()
    {
        TrapMove();
    }
    public virtual void TrapMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,lengRaycast, layerPlayer);
        if (hit.collider)
        {
            spriteRenderer.DOColor(Color.red, 0.5f)
                .SetLoops(10, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    animmFallChicken.Fall();
                    transform.DOLocalMoveY(hit.point.y, time1)
                    .OnComplete(() =>
                    {
                        animmFallChicken.Ground();
                        transform.DOLocalMoveY(oldPos, time2);
                    });
                });
        }
    }

   
}
