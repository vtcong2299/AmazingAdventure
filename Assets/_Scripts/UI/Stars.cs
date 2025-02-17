using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public GameObject[] star = new GameObject[3];

    public void CheckStars(int id)
    {
        if (DataManager.Instance.gameData.idMapCompeleteThreeStar.Contains(id))
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
        }
        else if (DataManager.Instance.gameData.idMapCompeleteTwoStar.Contains(id))
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(false);
        }
        else if (DataManager.Instance.gameData.idMapCompeleteOneStar.Contains(id))
        {
            star[0].SetActive(true);
            star[1].SetActive(false);
            star[2].SetActive(false);
        }
        else
        {
            star[0].SetActive(false);
            star[1].SetActive(false);
            star[2].SetActive(false);
        }
    }
}
