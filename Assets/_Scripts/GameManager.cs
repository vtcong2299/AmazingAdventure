using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public bool isPlayMobile;

    private void Start()
    {
        PlayerCtrl.Instance.StartPlayer();
        UIManager.Instance.StartUIManager();
        Joystick.Instance.StartJoystick();
        AudioManager.Instance.StartAudio();
        SetBG();
        SetLevel(0);
    }  
    private void Update()
    {
        SetParentOfPlayer();
    }
    public void ManagerPlayerHeartUI(float hp)
    {
        UIManager.Instance._uiGamePlay.HeartUI(hp);
    }
    public void ManagerStarsUI(int stars)
    {
        UIManager.Instance._uiGamePlay.StarsUI(stars);
    }
    public void ManagerOnChangeCoins(int coins)
    {
        UIManager.Instance._uiGamePlay.OnChangeCoins(coins);
    }
    public void ManagerEndChapter(int coins, int stars)
    {
        UIManager.Instance.FinishChapter(coins,stars);
    }
    public void DestroyObjInMap()
    {
        SpawnObj.Instance.DestroyObj();
    }
    public void SpawnObjInMap()
    {
        SpawnObj.Instance.AddPosObj();
        SpawnObj.Instance.Spawn();
    }
    public void ResetObjInMap()
    {
        SpawnObj.Instance.ResetObj();
    }   
    public void SetLevel(int level)
    {
        player.SetActive(false);
        LevelManager.Instance.SelectLevel(level);
    }
    public void SetBG()
    {
        BGManager.instance.RandomBG();
    }

    public void SetParentOfPlayer()
    {
        if (!player.gameObject.activeSelf)
        {
            player.transform.SetParent(null);
        }
    }
    public void SelectLevel(int level)
    {
        UIManager.Instance.SelectLevel();
        SetBG();
        SetLevel(level);
        player.SetActive(true);
        PlayerCtrl.Instance.BackCheckPoint();
        PlayerCtrl.Instance.SetStartPos();
        SpawnObjInMap();
    }
    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();     
    }
    public void UnLoadLevel()
    {
        SetLevel(0);
        DestroyObjInMap();
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
    }
}
