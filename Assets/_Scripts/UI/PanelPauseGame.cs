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
    public void PressLevelMenu()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
        UIManager.Instance.OnEnablePanelLevel();
    }
    public void ClickPlayButton()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
        Time.timeScale = 1f;
    }
    public void ClickRePlayButton()
    {
        PlayerMove.instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelPauseGame();
        UIManager.Instance.OnDisablePanelGamePlay();
        Time.timeScale = 1f;
    }
    public void ClickHomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
