using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanHit : EnemyHit
{
    public AnimPlan animPlan;
    private void Awake()
    {
        animPlan = GetComponent<AnimPlan>();
    }
    public override void AnimHit()
    {
        animPlan.PlanHit();
    }
}
