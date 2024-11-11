using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MushroomMove : EnemyMove
{
    private AnimationMushroom animationMushroom;
    private void Awake()
    {
        targetPoint = new Vector3[2];
        SpeedEnemy();
        animationMushroom = GetComponent<AnimationMushroom>();
        targetPoint[0] =new Vector3(transform.position.x - 1.2f, transform.position.y, transform.position.z);
        targetPoint[1] = new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z);
    }
    //private void Start()
    //{
    //    StartMushroom();
    //}
    //public void StartMushroom()
    //{
    //    StartCoroutine(ExampleCoroutine());
    //    animationMushroom.MushroomRun();
    //}        
    //IEnumerator ExampleCoroutine()
    //{        
    //        while (true)
    //        {
    //            yield return new WaitForSeconds(6f);
    //            speed = 0;
    //            animationMushroom.MushroomNotRun();
    //            yield return new WaitForSeconds(4f);
    //            speed = 0.5f;
    //            animationMushroom.MushroomRun();
    //        }
    //}
}

