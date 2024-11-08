using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHit : EnemyHit
{    
    private AnimationMushroom animationMushroom;
    private void Awake()
    {
        animationMushroom = GetComponent<AnimationMushroom>();
    }
    public override void AnimHit()
    {
        animationMushroom.MushroomHit();
    }
}
