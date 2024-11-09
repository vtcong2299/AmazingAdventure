using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanHit : EnemyHit
{
    private AnimPlan animPlan;
    private void Awake()
    {
        animPlan = GetComponent<AnimPlan>();
    }
    public override void AnimHit()
    {
        animPlan.PlanHit();
    }
}
