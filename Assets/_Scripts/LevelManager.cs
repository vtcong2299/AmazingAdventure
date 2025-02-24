using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    int curID;
    int maxLevel = 2;
    [SerializeField] ConfigMap[] configMap;
    [SerializeField] GameObject currentMap;
    [SerializeField] GameObject waitMap;

    [SerializeField] Stars[] starsLevel;
    [SerializeField] GameObject[] lockMap;

    public int targetApple;
    public int targetBanana;
    public int targetCherry;
    public void SelectLevel(int idMap)
    {
        foreach (ConfigMap map in configMap)
        {
            if (map._id == idMap)
            {
                curID = map._id;
                waitMap = Resources.Load<GameObject>(map._name);
                targetApple = map._targetApple;
                targetBanana = map._targetBanana;
                targetCherry = map._targetCherry;
                break;
            }
            else
            {
                waitMap = null;
            }
        }
        if (currentMap != null)
        {
            Destroy(currentMap);
            Resources.UnloadUnusedAssets();
        }
        if (waitMap == null)
        {
            return;
        }
        currentMap = Instantiate(waitMap, transform.position, transform.rotation);
    }
    public void NextLevel()
    {
        curID++;
        if (curID > maxLevel)
        {
            curID = 1;
        }
        GameManager.Instance.SelectLevel(curID);
    }
    public void CheckUnLockMap()
    {
        foreach (ConfigMap map in configMap)
        {
            if (map._id <= DataManager.Instance.gameData.idMapCompeleteMax + 1)
            {
                lockMap[map._id - 1].SetActive(false);
            }
            else
            {
                lockMap[map._id - 1].SetActive(true);
            }
        }            
    }
    public void CheckCompleteMap()
    {
        foreach (ConfigMap map in configMap)
        {
            starsLevel[map._id - 1].gameObject.SetActive(true);
            starsLevel[map._id - 1].CheckStars(map._id);
        }
    }
    public void AddMapCompeleteToList(int apple, int banana, int cherry, int idCurMap, int star)
    {
        if (apple < targetApple || banana < targetBanana || cherry < targetCherry || star == 0)
        {
            return;
        }
        foreach (ConfigMap map in configMap)
        {
            if (map._id == idCurMap)
            {
                if (DataManager.Instance.gameData.idMapCompeleteMax < map._id)
                {
                    DataManager.Instance.gameData.idMapCompeleteMax = map._id;
                }
                if (star == 3)
                {
                    DataManager.Instance.gameData.idMapCompeleteThreeStar.Add(map._id);
                    if (DataManager.Instance.gameData.idMapCompeleteTwoStar.Contains(map._id))
                    {
                        DataManager.Instance.gameData.idMapCompeleteTwoStar.Remove(map._id);
                    }
                    if (DataManager.Instance.gameData.idMapCompeleteOneStar.Contains(map._id))
                    {
                        DataManager.Instance.gameData.idMapCompeleteOneStar.Remove(map._id);
                    }
                }
                else if (star == 2 && !DataManager.Instance.gameData.idMapCompeleteThreeStar.Contains(map._id))
                {
                    DataManager.Instance.gameData.idMapCompeleteTwoStar.Add(map._id);
                    if (DataManager.Instance.gameData.idMapCompeleteOneStar.Contains(map._id))
                    {
                        DataManager.Instance.gameData.idMapCompeleteOneStar.Remove(map._id);
                    }
                }
                else if (star == 1 && !DataManager.Instance.gameData.idMapCompeleteThreeStar.Contains(map._id)
                    && !DataManager.Instance.gameData.idMapCompeleteTwoStar.Contains(map._id))
                {
                    DataManager.Instance.gameData.idMapCompeleteOneStar.Add(map._id);
                }
                CheckUnLockMap();
                CheckCompleteMap();
                DataManager.Instance.SaveData();
                break;
            }
        }
    }
}
