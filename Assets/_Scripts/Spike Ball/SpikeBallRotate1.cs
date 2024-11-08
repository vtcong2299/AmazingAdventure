using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallRotate1 : MonoBehaviour
{
    [SerializeField]
    private float speedSpikeBall = 150f;
    private float angle;
    private void Update()
    {
        RotateSpikeBall();
    }
    public void RotateSpikeBall()
    {
        angle -= speedSpikeBall * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
