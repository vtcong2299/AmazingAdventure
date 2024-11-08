using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{    
    Start,
    Playing,
    Pause
}
public class GameManager : MonoBehaviour
{
    public GameState curState;
    public static GameManager instance;
    public GameObject[] listChapter;
    public int index = 10000;
    public int count = 0;
    public GameObject player;
    private GameObject mainPlayer;
    private GameObject enemy;
    private GameObject enemyManager;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Start()
    {
        SetBG();
        player = GameObject.Find("Player");
        mainPlayer = GameObject.Find("MainPlayer");
        enemy = GameObject.Find("Enemy");
        enemyManager = GameObject.Find("EnemyManager");
        UnActiveAllLevel();
    }       
    private void Update()
    {
        SetParentOfPlayer();
        switch (curState)
        {
            case GameState.Playing:
                {
                    if (!SpawnPlan.instance.hasChild)
                    {
                        return;
                    }
                    SpawnBullet.instance.UpdateBullet();
                    break;
                }
            case GameState.Pause:
                {
                    break;
                }
        }        
    }
    public void ManagerHeartUI(float hp)
    {
        UIManager.instance.HeartUI(hp);
    }
    public void ManagerStarsUI(int stars)
    {
        UIManager.instance.StarsUI(stars);
    }
    public void ManagerOnChangeCoins(int coins)
    {
        UIManager.instance.OnChangeCoins(coins);
    }
    public void ManagerEndChapter(int coins, int stars)
    {
        UIManager.instance.CheckEndChapter(coins);
        UIManager.instance.StarsUIEnd(stars);
    }
    public void DestroyObj()
    {
        SpawnMushroom.instance.DestroyObj();
        SpawnCoins.instance.DestroyObj();
        SpawnStars.instance.DestroyObj();
        SpawnHeart.instance.DestroyObj();
        SpawnFalingFlatform.instance.DestroyObj();
        SpawnBlueBird.instance.DestroyObj();
        SpawnBoxRock.instance.DestroyObj();
        SpawnBat.instance.DestroyObj();
        SpawnPlan.instance.DestroyObj();
        SpawnBullet.instance.DestroyObj();
    }
    public void SpawnObj()
    {
        SpawnMushroom.instance.AddPosObj();
        SpawnMushroom.instance.Spawn();
        SpawnCoins.instance.AddPosObj();
        SpawnCoins.instance.Spawn();
        SpawnStars.instance.AddPosObj();
        SpawnStars.instance.Spawn();
        SpawnHeart.instance.AddPosObj();
        SpawnHeart.instance.Spawn();
        SpawnFalingFlatform.instance.AddPosObj();
        SpawnFalingFlatform.instance.Spawn();
        SpawnBlueBird.instance.AddPosObj();
        SpawnBlueBird.instance.Spawn();
        SpawnBoxRock.instance.AddPosObj();
        SpawnBoxRock.instance.Spawn();
        SpawnBat.instance.AddPosObj(); 
        SpawnBat.instance.Spawn();
        SpawnPlan.instance.AddPosObj();
        SpawnPlan.instance.Spawn();
        SpawnBullet.instance.AddPosObj();
    }
    public void ResetObj()
    {
        SpawnCoins.instance.ResetObj();
        SpawnStars.instance.ResetObj();
        SpawnHeart.instance.ResetObj();
        SpawnMushroom.instance.ResetObj();
        SpawnFalingFlatform.instance.ResetObj();
        SpawnBlueBird.instance.ResetObj();  
        SpawnBoxRock.instance.ResetObj();
        SpawnBat.instance.ResetObj();
        SpawnPlan.instance.ResetObj();
        SpawnBullet.instance.ResetObj();
    }   
    public void UnActiveAllLevel()
    {
        player.SetActive(false);
        SetActiveChapter();
    }
    public void SetBG()
    {
        BGManager.instance.RandomBG();
    }
    public void SetActiveChapter()
    {
        for (int i = 0; i < listChapter.Length; i++)
        {
            if (i == index)
            {
                listChapter[i].SetActive(true);
            }
            else
            {
                listChapter[i].SetActive(false);
            }
        }
    }
    public void SetParentOfPlayer()
    {
        if (!player.gameObject.activeSelf)
        {
            mainPlayer.transform.SetParent(player.transform);
        }
    }
}
