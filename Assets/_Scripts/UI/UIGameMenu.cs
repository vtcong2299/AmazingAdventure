using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameMenu : Singleton<UIGameMenu>
{
    [SerializeField] GameObject panelStratGame;
    [SerializeField] GameObject panelOption;
    [SerializeField] GameObject panelQuitGame;
    [SerializeField] GameObject panelLoading;

    [SerializeField] GameObject optionPopup;
    [SerializeField] GameObject quitGamePopup;
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
    public void OnEnablePanelStartGame()
    {
        panelStratGame.SetActive(true);
    }
    public void OnDisablePanelStartGame()
    {
        panelStratGame.SetActive(false);
    }
    public void OnEnablePanelLoading()
    {
        panelLoading.SetActive(true);
    }
    public void OnDisablePanelLoading()
    {
        panelLoading.SetActive(false);
    }
    public void LoadScene()
    {
        StartCoroutine(Scene.Instance.LoadSceneWithDelay(1, panelLoading));
    }
}
