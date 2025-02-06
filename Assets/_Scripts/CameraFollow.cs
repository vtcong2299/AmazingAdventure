using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] float speedFollow = 5f;
    [SerializeField] float lengthRaycastY = 1.35f;
    [SerializeField] float lengthRaycastX = 2.7f;
    [SerializeField] LayerMask blackLayer;
    [SerializeField] Transform target;
    [SerializeField] Vector3 startPosCamera;
    //[SerializeField] Vector3 endPosCamera;
    [SerializeField] LayerMask lockCameraLayer;
    private void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {   
        Vector3 posCamera = transform.position;
        RaycastHit2D hitX1 = Physics2D.Raycast(target.position, -target.right, lengthRaycastX, lockCameraLayer);
        RaycastHit2D hitX2 = Physics2D.Raycast(target.position, target.right, lengthRaycastX, lockCameraLayer);
        if ( hitX1.collider || hitX2.collider)
        {
            posCamera.x = transform.position.x;
        }
        else
        {
            posCamera.x = target.position.x;
        }
        RaycastHit2D hitY = Physics2D.Raycast(target.position, -target.up, lengthRaycastY, blackLayer);
        if (hitY.collider)
        {
            posCamera.y = hitY.point.y + lengthRaycastY;
        }
        else if (target.position.y <= startPosCamera.y && target.position.y >= 0)
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
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(target.position, -target.up * lengthRaycastY);
        //Gizmos.DrawRay(target.position, -target.right * lengthRaycastX);
        //Gizmos.DrawRay(target.position, target.right * lengthRaycastX);
    }
    public void ResetCamera()
    {
        transform.position = startPosCamera;
    }
}
