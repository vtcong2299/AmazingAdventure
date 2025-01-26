using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class PanelGamePlay : MonoBehaviour
{
    [SerializeField] GameObject[] listHeartsUI;
    [SerializeField] GameObject[] listStarsUI;
    [SerializeField] Text txtCoins;
    [SerializeField] Text txtFPS;
    [SerializeField] int fps = 0;
    float timeDelayUpdatePfs = 0f;
    [SerializeField] GameObject ctrlOnMobile;
    [SerializeField] Button pauseButton;
    [SerializeField] Button jumpButton;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;

    private void Awake()
    {
        pauseButton.onClick.AddListener(ClickPauseButton);
    }

    private void Update()
    {
        CaculateFPS();
        if (GameManager.instance.isPlayPC)
        {
            ctrlOnMobile.SetActive(false);
        }
        else
        {
            ctrlOnMobile.SetActive(true);
        }
    }
    public void OnChangeCoins(int coins)
    {
        txtCoins.text = "x " + coins;
    }

    public void OnFPS(int fps)
    {
        txtFPS.text = "FPS: " + fps;
    }

    public void CaculateFPS()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        timeDelayUpdatePfs += Time.unscaledDeltaTime;
        if (timeDelayUpdatePfs >= 0.3f)
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

    void ClickPauseButton()
    {
        UIManager.Instance.OnEnablePanelPauseGame();
        Time.timeScale = 0f;
    }

    public void ClickJumpButton()
    {
        PlayerMove.Instance.ClickJump();
    }

    public void NotClickJumpButton()
    {
        PlayerMove.Instance.NotClickJump();
    }

    public void ClickLeftButton()
    {
        PlayerMove.Instance.PressLeft();
    }

    public void ClickRightButton()
    {
        PlayerMove.Instance.PressRight();
    }

    public void NotClickMoveButton()
    {
        PlayerMove.Instance.NoPressLeftRight();
    }
}
