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
    [SerializeField] Button musicButton;
    [SerializeField] Button soundButton;

    [SerializeField] SettingSound settingSound;
    private void Start()
    {
        playButton.onClick.AddListener(ClickPlayButton);
        rePlayButton.onClick.AddListener(ClickRePlayButton);
        homeButton.onClick.AddListener(ClickHomeButton);
        levelButton.onClick.AddListener(PressLevelMenu);
        musicButton.onClick.AddListener(ClickMusicButton);
        soundButton.onClick.AddListener(ClickSoundButton);
        settingSound.SetUpIconSound(DataManager.Instance.gameData.hasSFX);
        settingSound.SetUpIconMusic(DataManager.Instance.gameData.hasBGM);
    }
    public void PressLevelMenu()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
        GameManager.Instance.UnLoadLevel();
    }
    public void ClickPlayButton()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
        DataManager.Instance.SaveData();
    }
    public void ClickRePlayButton()
    {
        UIManager.Instance.AnimPanelLoading();
        PlayerCtrl.Instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelPauseGame();
        DataManager.Instance.SaveData();
    }
    public void ClickHomeButton()
    {
        UIManager.Instance.OnDisablePanelPauseGame();
        UIManager.Instance.LoadScene();
    }
    void ClickMusicButton()
    {
        AudioManager.Instance.SoundClickButton();
        AudioManager.Instance.SetVolumAudioBGM(!DataManager.Instance.gameData.hasBGM);
        settingSound.SetUpIconMusic(!DataManager.Instance.gameData.hasBGM);
        DataManager.Instance.gameData.hasBGM = !DataManager.Instance.gameData.hasBGM;
    }
    void ClickSoundButton()
    {
        AudioManager.Instance.SoundClickButton();
        AudioManager.Instance.SetVolumAudioSFX(!DataManager.Instance.gameData.hasSFX);
        settingSound.SetUpIconSound(!DataManager.Instance.gameData.hasSFX);
        DataManager.Instance.gameData.hasSFX = !DataManager.Instance.gameData.hasSFX;
    }
}
