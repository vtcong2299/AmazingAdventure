using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : Singleton<BGManager>
{
    [SerializeField] GameObject[] backGround;
    [SerializeField] int index = 0;
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
