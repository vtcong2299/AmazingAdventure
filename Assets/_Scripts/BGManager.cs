using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public static BGManager instance;
    [SerializeField]
    private GameObject[] backGround;
    [SerializeField]
    private int index = 0;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void RandomBG()
    {
        index = Random.Range(0, backGround.Length);
        for (int i = 0; i < backGround.Length; i++)
        {
            if (i == index)
            {
                backGround[i].SetActive(true);
            }
            else
            {
                backGround[i].SetActive(false);
            }
        }
    }
}
