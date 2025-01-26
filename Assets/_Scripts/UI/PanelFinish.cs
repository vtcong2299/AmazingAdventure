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

    void SelectLevel1()
    {
        UIManager.Instance.OnDisablePanelLevel();
        GameManager.instance.Level1();
    }
    void SelectLevel2()
    {
        UIManager.Instance.OnDisablePanelLevel();
        GameManager.instance.Level2();
    }
    public void PressNextLevel()
    {
        GameManager.instance.NextLevel();
        PressLevelMenu();
        UIManager.Instance.AnimPanelLoading();
        switch (GameManager.instance.curChapter)
        {
            case 0:
                {
                    Invoke("SelectLevel1", 0.3f);
                    break;
                }
            case 1:
                {
                    Invoke("SelectLevel2", 0.3f);
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
        PlayerMove.Instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelFinish();
        Time.timeScale = 1f;
    }
    public void ClickHomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
