using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFPS : MonoBehaviour
{
    [SerializeField] Button button30;
    [SerializeField] Button button45;
    [SerializeField] Button button60;
    [SerializeField] Button button90;

    private void Start()
    {
        button30.onClick.AddListener(CLickButton30);
        button45.onClick.AddListener(CLickButton45);
        button60.onClick.AddListener(CLickButton60);
        button90.onClick.AddListener(CLickButton90);
    }
    void CLickButton30()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.gameData.fps = 30;
        UIGameMenu.Instance.OnDisablePanelFPS();
    }
    void CLickButton45()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.gameData.fps = 45;
        UIGameMenu.Instance.OnDisablePanelFPS();
    }
    void CLickButton60()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.gameData.fps = 60;
        UIGameMenu.Instance.OnDisablePanelFPS();
    }
    void CLickButton90()
    {
        AudioManager.Instance.SoundClickButton();
        DataManager.Instance.gameData.fps = 90;
        UIGameMenu.Instance.OnDisablePanelFPS();
    }
}
