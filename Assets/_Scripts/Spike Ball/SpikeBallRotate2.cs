using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallRotate2 : MonoBehaviour
{
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float interpolationValue = 0.0f;
    [SerializeField]
    private float speedSpikeBall = 5f;
    [SerializeField]
    private Vector3 angle1 = new Vector3(0, 0, -60); 
    [SerializeField]
    private Vector3 angle2 = new Vector3(0, 0, 60);  
    [SerializeField]
    private bool reverse = false;

    void Awake()
    {
        startRotation = Quaternion.Euler(angle1);
        endRotation = Quaternion.Euler(angle2);
    }
    void Update()
    {
        RotateSpikeBall();
    }
    public void RotateSpikeBall()
    {
        // Cập nhật giá trị nội suy
        interpolationValue += (reverse ? -1 : 1) * speedSpikeBall * 0.1f * Time.deltaTime;
        if (interpolationValue > 1.0f)
        {
            interpolationValue = 1.0f;
            reverse = true;
        }
        else if (interpolationValue < 0.0f)
        {
            interpolationValue = 0.0f;
            reverse = false;
        }

        // Nội suy giữa các góc
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, interpolationValue);
    }
}


