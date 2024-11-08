using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHit : EnemyHit
{
    private AnimBat animBat;
    private void Awake()
    {
        animBat = GetComponent<AnimBat>();
    }
    public override void AnimHit()
    {
        animBat.BatHit();
    }
}
