using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    [SerializeField]
    private float speedFollow = 5f;
    [SerializeField]
    private float lengthRaycast = 1.35f;
    [SerializeField]
    private LayerMask blackLayer;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 startPosCamera;
    [SerializeField]
    private Vector3 endPosCamera;
    private void Awake()
    {
        startPosCamera.x = target.position.x + 1.85f;
    }
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
        if (target.position.x >= startPosCamera.x && target.position.x <= 7.9)
        {
            posCamera.x = target.position.x;
        }
        else if (target.position.x < startPosCamera.x)
        {
            posCamera.x = startPosCamera.x;
        }
        else
        {
            posCamera.x = endPosCamera.x;   
        }
        RaycastHit2D hit = Physics2D.Raycast(target.position, -target.up, lengthRaycast, blackLayer);
        if (hit.collider)
        {
            posCamera.y = hit.point.y + lengthRaycast;
        }
        else if (target.position.y <= startPosCamera.y && target.position.y>= 0)
        {
            posCamera.y = startPosCamera.y;
        }
        else 
        {
            posCamera.y = target.position.y;
        }

        Vector3 newPos = new Vector3(posCamera.x, posCamera.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, speedFollow*Time.deltaTime);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawRay(target.position, -target.up * lengthRaycast); 
    }
        public void ResetCamera()
    {
        transform.position = startPosCamera;
    }
}
