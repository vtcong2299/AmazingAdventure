using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] float speedFollow = 5f;
    [SerializeField] float lengthRaycastY = 1.27f;
    [SerializeField] float lengthRaycastX = 2.6f;
    [SerializeField] LayerMask blackLayer;
    [SerializeField] Transform target;
    [SerializeField] LayerMask lockCameraLayer;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        float orthographicSize = mainCamera.orthographicSize;
        float screenHeightInUnits = 2 * orthographicSize;
        float aspectRatio = (float)Screen.width / Screen.height;
        float screenWidthInUnits = screenHeightInUnits * aspectRatio;

        lengthRaycastY = screenHeightInUnits / 2;
        lengthRaycastX = screenWidthInUnits / 2;
    }
    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 posCamera = transform.position;
        RaycastHit2D hitX1 = Physics2D.Raycast(target.position, -target.right, lengthRaycastX, lockCameraLayer);
        RaycastHit2D hitX2 = Physics2D.Raycast(target.position, target.right, lengthRaycastX, lockCameraLayer);
        if (hitX1.collider && hitX2.collider)
        {
            posCamera.x = target.position.x;
        }
        else if (hitX1.collider && PlayerCtrl.Instance.isFacingRight)
        {
            posCamera.x = hitX1.point.x + lengthRaycastX;
        }
        else if (hitX2.collider && !PlayerCtrl.Instance.isFacingRight)
        {
            posCamera.x = hitX2.point.x + lengthRaycastX;
        }
        else if (hitX1.collider && !PlayerCtrl.Instance.isFacingRight)
        {
            posCamera.x = hitX1.point.x - lengthRaycastX;
        }
        else if (hitX2.collider && PlayerCtrl.Instance.isFacingRight)
        {
            posCamera.x = hitX2.point.x - lengthRaycastX;
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
        else
        {
            posCamera.y = target.position.y;
        }

        Vector3 newPos = new Vector3(posCamera.x, posCamera.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, speedFollow * Time.deltaTime);
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(target.position, -target.up * lengthRaycastY);
    //    Gizmos.DrawRay(target.position, -target.right * lengthRaycastX);
    //    Gizmos.DrawRay(target.position, target.right * lengthRaycastX);
    //}
}
