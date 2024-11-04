using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab của object
    public int rows = 16; // Số hàng
    public int columns = 32; // Số cột
    public float spacing = 0.64f; // Khoảng cách giữa các object

    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(j * spacing, i * spacing, 0);
                Instantiate(objectPrefab, position, Quaternion.identity);
            }
        }

    }
}
