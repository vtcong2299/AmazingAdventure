using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChickenHit : EnemyHit
{
    private AnimmFallChicken animmFallChicken;
    private void Awake()
    {
        animmFallChicken = GetComponent<AnimmFallChicken>();
    }
    public override void AnimHit()
    {
        animmFallChicken.Hit();
    }
}
