using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelStartGame : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button resetDataButton;
    [SerializeField] Button ctrlButton;
    [SerializeField] Text txtCtrl;

    private void Start()
    {
        playButton.onClick.AddListener(ClickStartButton);
        optionsButton.onClick.AddListener(ClickOptionsButton);
        exitButton.onClick.AddListener(ClickExitButton);
        resetDataButton.onClick.AddListener(ClickResetDataButton);
        ctrlButton.onClick.AddListener(ClickCtrlButton);
    }
    private void Update()
    {
        CheckTextCtrlButton();
    }
    void ClickStartButton()
    {
        AudioManager.Instance.SoundClickButton();
        UIGameMenu.Instance.LoadScene();
        Time.timeScale = 1.0f;
    }

    void ClickOptionsButton()
    {
        AudioManager.Instance.SoundClickButton();
        UIGameMenu.Instance.OnEnablePanelOption();
        UIGameMenu.Instance.OnDisablePanelStartGame();
    }

    void ClickExitButton()
    {
        AudioManager.Instance.SoundClickButton();
        UIGameMenu.Instance.OnEnablePanelQuitGame();
    }

    void ClickResetDataButton()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.ResetData();
    }
    void ClickCtrlButton()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.gameData.isPlayOnMobile = !DataManager.Instance.gameData.isPlayOnMobile;
        CheckTextCtrlButton();
        DataManager.Instance.SaveData();
    }
    void CheckTextCtrlButton()
    {
        if (DataManager.Instance.gameData.isPlayOnMobile)
        {
            txtCtrl.text = "Mobile";
        }
        else
        {
            txtCtrl.text = "PC";
        }
    }
}
