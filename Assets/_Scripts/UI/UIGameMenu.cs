using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameMenu : Singleton<UIGameMenu>
{
    [SerializeField] GameObject panelStratGame;
    [SerializeField] GameObject panelOption;
    [SerializeField] GameObject panelQuitGame;
    [SerializeField] GameObject panelLoading;
    [SerializeField] GameObject panelFPS;

    [SerializeField] GameObject optionPopup;
    [SerializeField] GameObject quitGamePopup;
    [SerializeField] GameObject fpsPopup;

    [SerializeField] Image imageCharacter;

    public void Start()
    {
        Init();
    }
    void Init()
    {
        panelStratGame.SetActive(true);
        panelOption.SetActive(false);
        panelQuitGame.SetActive(false);
        panelLoading.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnEnablePanelOption()
    {
        AnimUI.Instance.AnimScaleOut(optionPopup, panelOption);
    }
    public void OnDisablePanelCharacter()
    {
        AnimUI.Instance.AnimScaleIn(optionPopup, panelOption);
    }
    public void OnEnablePanelQuitGame()
    {
        AnimUI.Instance.AnimScaleOut(quitGamePopup, panelQuitGame);
    }
    public void OnDisablePanelQuitGame()
    {
        AnimUI.Instance.AnimScaleIn(quitGamePopup, panelQuitGame);
    }
    public void OnEnablePanelFPS()
    {
        AnimUI.Instance.AnimScaleOut(fpsPopup, panelFPS);
    }
    public void OnDisablePanelFPS()
    {
        AnimUI.Instance.AnimScaleIn(fpsPopup, panelFPS);
    }
    public void OnEnablePanelStartGame()
    {
        panelStratGame.SetActive(true);
    }
    public void OnDisablePanelStartGame()
    {
        panelStratGame.SetActive(false);
    }
    public void LoadScene()
    {
        StartCoroutine(Scene.Instance.LoadSceneWithDelay(1, panelLoading));
    }
    public void ChangeImageCharaterUI(Sprite image)
    {
        imageCharacter.sprite = image;
    }
}
