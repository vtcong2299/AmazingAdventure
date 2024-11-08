using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    private Vector3 posBG;
    [SerializeField]
    private float speed=0.3f;
    [SerializeField]
    private float xSpawn=25.2f;
    [SerializeField]
    private float xReset = -12.6f;
    private void Awake()
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
        if (posBG.x <=xReset)
        {
            posBG.x = xSpawn;    
        }
    }
}
