using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdHit : EnemyHit
{
    private AnimBlueBird animBlueBird;
    private void Awake()
    {
        animBlueBird = GetComponent<AnimBlueBird>();
    }
    public override void AnimHit()
    {
        animBlueBird.BlueBirdHit();
    }
}
