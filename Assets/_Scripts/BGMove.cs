using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public Vector3 posBG;
    public float speed=0.5f;
    public float x=20.79f;
    private void Start()
    {
        posBG = transform.position;
    }
    private void Update()
    {
        Move();
    }
    public void Move() 
    {
        posBG.x -= speed*Time.deltaTime;
        transform.position = posBG;
        if (posBG.x <=-0.63)
        {
            posBG.x = x;    
        }
    }
}
