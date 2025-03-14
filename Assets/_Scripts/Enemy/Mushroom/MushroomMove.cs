using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMove : EnemyBaseMove
{
    private AnimationMushroom animationMushroom;
    
    private void Awake()
    {
        targetPoint = new Vector3[2];
        animationMushroom = GetComponent<AnimationMushroom>();
        targetPoint[0] =new Vector3(transform.position.x - offset.x, transform.position.y, transform.position.z);
        targetPoint[1] = new Vector3(transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
    void OnEnable()
    {
        StartCoroutine(ExampleCoroutine());
        animationMushroom.MushroomRun();
        speed = 0.5f;
    }
    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5,8));
            speed = 0;
            animationMushroom.MushroomNotRun();
            yield return new WaitForSeconds(Random.Range(4,6));
            speed = 0.5f;
            animationMushroom.MushroomRun();
        }
    }
}

