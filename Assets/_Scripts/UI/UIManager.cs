using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text txtCoins;
    public Text txtCoinsEnd;
    public GameObject[] listHeartsUI;
    public GameObject[] listStarsUI;
    public GameObject[] listStarsUIEnd;
    public GameObject panelPauseGame;
    public GameObject panelHienThiPlayGame;
    public GameObject panelEndChapter;
    private void Awake()
    {
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
    public void OnChangeCoins(int coins)
    {
        txtCoins.text = "x " + coins;
    } 
    public void OnCoinsEnd(int coins)
    {
        txtCoinsEnd.text = "x " + coins;
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
        PlayerVsItem.instance.ResetItem();
        PlayerVsItem.instance.ResetEnemy();
        PlayerVsItem.instance.ResetPlayerParameter();
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
