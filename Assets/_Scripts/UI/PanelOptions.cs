using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOptions : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button musicButton;
    [SerializeField] Button soundButton;
    [SerializeField] Button selectButton;
    [SerializeField] Button fpsButton;

    [SerializeField] SettingSound settingSound;
    private void Start()
    {
        backButton.onClick.AddListener(ClickBackButton);
        leftButton.onClick.AddListener(ClickLeftButton);
        rightButton.onClick.AddListener(ClickRightButton);
        musicButton.onClick.AddListener(ClickMusicButton);
        soundButton.onClick.AddListener(ClickSoundButton);
        selectButton.onClick.AddListener(ClickSelectButton);
        fpsButton.onClick.AddListener(ClickFPSButton);
        settingSound.SetUpIconSound(DataManager.Instance.gameData.hasSFX);
        settingSound.SetUpIconMusic(DataManager.Instance.gameData.hasBGM);
    }
    private void OnEnable()
    {
        DataManager.Instance.ShowCharacterSelecting();
    }
    void ClickBackButton()
    {
        AudioManager.Instance.SoundClickButton();
        UIGameMenu.Instance.OnEnablePanelStartGame();
        UIGameMenu.Instance.OnDisablePanelCharacter();
        DataManager.Instance.SaveData();
    }
    void ClickLeftButton()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.BackSelectCharacter();
    }
    void ClickRightButton()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.NextSelectCharacter();
    }
    public void ClickSelectButton()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.UpdateSelectCharacter();
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
    void ClickFPSButton()
    {
        AudioManager.Instance.SoundClickButton();
        UIGameMenu.Instance.OnEnablePanelFPS();
    }
}
