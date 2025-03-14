using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    [SerializeField] int idCurMap = 0;
    protected override void Awake()
    {
        base.Awake();
        SetBG();
        SetLevel(0);
    }
    private void Start()
    {
        LevelManager.Instance.CheckUnLockMap();
        LevelManager.Instance.CheckCompleteMap();
        DataManager.Instance.CheckInterfacePlayer();
    }
    private void OnEnable()
    {
        DataManager.Instance.SetFPS();
    }
    public void ManagerPlayerHeartUI(float hp)
    {
        UIManager.Instance._uiGamePlay.HeartUI(hp);
    }
    public void ManagerStarsUI(int stars)
    {
        UIManager.Instance._uiGamePlay.StarsUI(stars);
    }
    public void ManagerOnChangeApple(int apple)
    {
        UIManager.Instance._uiGamePlay.OnChangeApple(apple);
    }
    public void ManagerOnChangeBanana(int banana)
    {
        UIManager.Instance._uiGamePlay.OnChangeBanana(banana);
    }
    public void ManagerOnChangeCherry(int cherry)
    {
        UIManager.Instance._uiGamePlay.OnChangeCherry(cherry);
    }
    public void ResetUI(int apple, int banana, int cherry, int stars, float hp)
    {
        ManagerPlayerHeartUI(hp);
        ManagerOnChangeApple(apple);
        ManagerOnChangeBanana(banana);
        ManagerOnChangeCherry(cherry);
        ManagerStarsUI(stars);
    }
    public void ManagerEndChapter(int apple, int banana, int cherry, int stars)
    {
        LevelManager.Instance.AddMapCompeleteToList(apple, banana, cherry, idCurMap, stars);
        UIManager.Instance.FinishChapter(apple, banana,cherry,stars);
    }
    public void ClearListObj()
    {
        SpawnObj.Instance.ClearListObj();
    }
    public void AddToListObj()
    {
        SpawnObj.Instance.AddToListObj();
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
        BGManager.Instance.RandomBG();
    }

    public void SelectLevel(int level)
    {
        idCurMap = level;
        UIManager.Instance.SelectLevel();
        SetBG();
        SetLevel(level);
        player.SetActive(true);
        PlayerCtrl.Instance.BackCheckPoint();
        PlayerCtrl.Instance.SetStartPos();
        AddToListObj();
    }
    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();     
    }
    public void UnLoadLevel()
    {
        SetLevel(0);
        ClearListObj();
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
