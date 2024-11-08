using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] listHeartsUI;
    public GameObject[] listStarsUI;
    public GameObject[] listStarsUIEnd;
    [SerializeField]
    private Text txtCoins;
    [SerializeField]
    private Text txtCoinsEnd;
    [SerializeField]
    private Text txtFPS;
    [SerializeField]
    private GameObject panelPauseGame;
    [SerializeField]
    private GameObject panelHienThiPlayGame;
    [SerializeField]
    private GameObject panelEndChapter;
    [SerializeField]
    private GameObject panelLevel;
    [SerializeField]
    private int fps = 0;
    [SerializeField]
    private float timeDelayUpdatePfs = 0f;
    private void Awake()
    {
        panelLevel.SetActive(true);
        panelHienThiPlayGame.SetActive(false);
        panelPauseGame.SetActive(false);
        panelEndChapter.SetActive(false);
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Update()
    {
        CaculateFPS();
    }
    public void OnChangeCoins(int coins)
    {
        txtCoins.text = "x " + coins;
    } 
    public void OnCoinsEnd(int coins)
    {
        txtCoinsEnd.text = "x " + coins;
    } 
    public void OnFPS(int fps)
    {
        txtFPS.text = "FPS: " + fps;
    }
    public void CaculateFPS()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        timeDelayUpdatePfs += Time.unscaledDeltaTime;
        if (fps >= 120)
        {
            fps = 120;
        }
        if (timeDelayUpdatePfs >= 0.5f)
        {
            OnFPS(fps);
            timeDelayUpdatePfs = 0f;
        }
    }
    public void HeartUI(float hp)
    {
        for (int i = 0; i < hp; i++)
        {
            listHeartsUI[i].SetActive(true);
        }
        for (int i = (int)hp; i < 3; i++)
        {
            listHeartsUI[i].SetActive(false);
        }
    } 
    public void StarsUI(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            listStarsUI[i].SetActive(true);
        }
        for (int i = stars; i < 3; i++)
        {
            listStarsUI[i].SetActive(false);
        }
    }
    public void StarsUIEnd(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            listStarsUIEnd[i].SetActive(true);
        }
        for (int i = stars; i < 3; i++)
        {
            listStarsUIEnd[i].SetActive(false);
        }
    }
    public void CheckEndChapter(int coins)
    {
        StartCoroutine(DelayPanelEnd(coins));
    }  
    IEnumerator DelayPanelEnd(int coins)
    {
        yield return new WaitForSeconds(0.5f);
        panelEndChapter.SetActive(true);
        panelHienThiPlayGame.SetActive(false);
        OnCoinsEnd(coins);
    }
    public void PressBack()
    {
        SceneManager.LoadScene(0);
    }
    public void PressLevel1()
    {
        GameManager.instance.SetBG();
        GameManager.instance.index = 0;
        GameManager.instance.UnActiveAllLevel();
        panelHienThiPlayGame.SetActive(true );
        panelLevel.SetActive(false);
        GameManager.instance.player.SetActive(true);
        PlayerMove.instance.SetStratPos();
        PlayerMove.instance.BackCheckPoint(); //Cần sưa lại BackCheckPoint
        Time.timeScale = 1.0f;
        GameManager.instance.curState = GameState.Playing;
        GameManager.instance.SpawnObj();
    }
    public void PressLevel2()
    {
        GameManager.instance.SetBG();
        GameManager.instance.index = 1;
        GameManager.instance.UnActiveAllLevel();
        panelHienThiPlayGame.SetActive(true );
        panelLevel.SetActive(false);
        GameManager.instance.player.SetActive(true);
        PlayerMove.instance.SetStratPos();
        PlayerMove.instance.BackCheckPoint();
        Time.timeScale = 1.0f;
        GameManager.instance.curState = GameState.Playing;
        GameManager.instance.SpawnObj();
    }
    public void PressNextLevel()
    {
        GameManager.instance.SetBG();
        GameManager.instance.DestroyObj();
        GameManager.instance.index++;
        if (GameManager.instance.index >= GameManager.instance.listChapter.Length)
        {
            GameManager.instance.index = 0;
        }
        GameManager.instance.UnActiveAllLevel();
        panelEndChapter.SetActive(false);
        GameManager.instance.player.SetActive(true);
        PlayerMove.instance.SetStratPos();
        PlayerMove.instance.BackCheckPoint();
        Time.timeScale = 1.0f;
        GameManager.instance.SpawnObj();
    }
    public void PressLevelMenu()
    {
        GameManager.instance.index = 10000;
        GameManager.instance.UnActiveAllLevel();
        panelLevel.SetActive(true);
        panelHienThiPlayGame.SetActive(false);
        panelPauseGame.SetActive(false);
        panelEndChapter.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.curState = GameState.Pause;
        GameManager.instance.DestroyObj();
    }
    public void ClickPauseButton()
    {
        panelPauseGame.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ClickPlayButton()
    {
        panelPauseGame.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ClickRePlayButton()
    {
        PlayerMove.instance.BackCheckPoint();
        panelPauseGame.SetActive(false);
        panelEndChapter.SetActive(false) ;
        panelHienThiPlayGame.SetActive(true) ;
        Time.timeScale = 1f;
    }
    public void ClickHomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
