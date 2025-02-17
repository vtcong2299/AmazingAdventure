using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelQuitGame : MonoBehaviour
{
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    private void Start()
    {
        yesButton.onClick.AddListener(QuitGame);
        noButton.onClick.AddListener(DisablePanelQuitGame);
    }
    void QuitGame()
    {
        AudioManager.Instance.SoundClickButton();
        Application.Quit();
    }
    void DisablePanelQuitGame()
    {
        AudioManager.Instance.SoundClickButton();
        UIGameMenu.Instance.OnDisablePanelQuitGame();
    }
}
