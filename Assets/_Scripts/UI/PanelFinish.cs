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
    void SelectLevel()
    {
        UIManager.Instance.OnDisablePanelLevel();
        GameManager.Instance.NextLevel();
    }
    public void PressNextLevel()
    {
        UIManager.Instance.AnimPanelLoading();
        GameManager.Instance.UnLoadLevel();
        UIManager.Instance.OnDisablePanelFinish();
        Invoke("SelectLevel", 0.3f);
    }   
    public void PressLevelMenu()
    {
        UIManager.Instance.OnDisablePanelFinish();
        UIManager.Instance.PressLevelMenu();
        GameManager.Instance.UnLoadLevel();
    }
    public void ClickRePlayButton()
    {
        PlayerCtrl.Instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelFinish();
    }
    public void ClickHomeButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
