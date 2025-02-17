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

    private void Start()
    {
        playButton.onClick.AddListener(ClickStartButton);
        optionsButton.onClick.AddListener(ClickOptionsButton);
        exitButton.onClick.AddListener(ClickExitButton);
        resetDataButton.onClick.AddListener(ClickResetDataButton);
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
}
