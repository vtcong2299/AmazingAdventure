using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class PanelFinish : MonoBehaviour
{
    public GameObject[] listStarsUIEnd;
    [SerializeField]
    private Text txtCoinsEnd;
    [SerializeField] Button replayButton;
    [SerializeField] Button homeButton;
    [SerializeField] Button levelButton;
    [SerializeField] Button nextLevelButton;
    private void Awake()
    {
        replayButton.onClick.AddListener(ClickRePlayButton);
        homeButton.onClick.AddListener(ClickHomeButton);
        levelButton.onClick.AddListener(PressLevelMenu);
        nextLevelButton.onClick.AddListener(PressNextLevel);
    }

    public void OnCoinsEnd(int coins)
    {
        txtCoinsEnd.text = "x " + coins;
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
    
    //public void PressLevel1()
    //{
    //    panelHienThiPlayGame.SetActive(true);
    //    panelLevel.SetActive(false);
    //    GameManager.instance.Level1();
    //}
    //public void PressLevel2()
    //{
    //    panelHienThiPlayGame.SetActive(true);
    //    panelLevel.SetActive(false);
    //    GameManager.instance.Level2();
    //}
    public void PressNextLevel()
    {
        GameManager.instance.NextLevel();
        PressLevelMenu();
        switch (GameManager.instance.curChapter)
        {
            case 0:
                {
                    Invoke("PressLevel1", 0.01f);
                    break;
                }
            case 1:
                {
                    Invoke("PressLevel2", 0.01f);
                    break;
                }
        }
    }
    public void PressLevelMenu()
    {
        UIManager.Instance.OnDisablePanelFinish();
        UIManager.Instance.OnEnablePanelLevel();
        GameManager.instance.LevelMenu();
    }
    public void ClickRePlayButton()
    {
        PlayerMove.instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelFinish();
        Time.timeScale = 1f;
    }
    public void ClickHomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
