using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class PanelPauseGame : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button rePlayButton;
    [SerializeField] Button homeButton;
    [SerializeField] Button levelButton;
    [SerializeField] Slider bgm;
    [SerializeField] Slider sfx;
    private void Awake()
    {
        playButton.onClick.AddListener(ClickPlayButton);
        rePlayButton.onClick.AddListener(ClickRePlayButton);
        homeButton.onClick.AddListener(ClickHomeButton);
        levelButton.onClick.AddListener(PressLevelMenu);
    }
    public void PressLevelMenu()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
        UIManager.Instance.PressLevelMenu();
        GameManager.Instance.UnLoadLevel();
    }
    public void ClickPlayButton()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
    }
    public void ClickRePlayButton()
    {
        UIManager.Instance.AnimPanelLoading();
        PlayerCtrl.Instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelPauseGame();
    }
    public void ClickHomeButton()
    {
        UIManager.Instance.AnimPanelLoading();
        SceneManager.LoadSceneAsync(0);
    }
}
