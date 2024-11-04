using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public float speedFollow = 5f;
    public Transform target;
    public Vector3 startPosCamera;     
    public Vector3 endPosCamera;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {   
        Vector3 posCamera = transform.position;
        if (target.position.x >= -7.7 && target.position.x <= 7.9)
        {
            posCamera.x = target.position.x;
        }
        else if (target.position.x < -7.7)
        {
            posCamera.x = startPosCamera.x;
        }
        else
        {
            posCamera.x = endPosCamera.x;   
        }
        if (target.position.y >= 1.2)
        {
            posCamera.y = target.position.y;
        }
        else
        {
            posCamera.y = startPosCamera.y;
        }
        Vector3 newPos = new Vector3(posCamera.x, posCamera.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, speedFollow*Time.deltaTime);
    }
    public void ResetCamera()
    {
        transform.position = startPosCamera;
    }
}
