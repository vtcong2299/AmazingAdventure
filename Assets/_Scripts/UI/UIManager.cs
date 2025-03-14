using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject panelGamePlay;
    [SerializeField] GameObject panelPauseGame;
    [SerializeField] GameObject panelFinish;
    [SerializeField] GameObject panelLevel;
    [SerializeField] GameObject panelLoading;
    [SerializeField] GameObject panelGuide;

    [SerializeField] CanvasGroup canvasGroupGamePlay;
    [SerializeField] CanvasGroup canvasGroupPauseGame;
    [SerializeField] CanvasGroup canvasGroupFinish;
    [SerializeField] CanvasGroup canvasGroupLevel;
    [SerializeField] CanvasGroup canvasGroupLoading;

    [SerializeField] GameObject popupPause;
    [SerializeField] GameObject popupFinish;
    public PanelGamePlay _uiGamePlay;
    public PanelFinish _uiFinish;
    protected override void Awake()
    {
        SetOffAllPanel();
        panelLevel.SetActive(true);
    }
    public void OnEnablePanelGamePlay()
    {
        ShowFade(panelGamePlay, canvasGroupGamePlay, false);
    }
    public void OnDisablePanelGamePlay()
    {
        HideFade(panelGamePlay, canvasGroupGamePlay, false);
    }
    public void OnEnablePanelPauseGame()
    {
        ShowScale(panelPauseGame, popupPause, true);
    }
    public void OnDisablePanelPauseGame()
    {
        HideScale(panelPauseGame, popupPause, true);
    }
    public void OnEnablePanelFinish()
    {
        ShowScale(panelFinish, popupFinish, false);
    }
    public void OnDisablePanelFinish()
    {
        HideScale(panelFinish, popupFinish, true);
    }
    public void OnEnablePanelLevel()
    {
        LevelManager.Instance.CheckUnLockMap();
        ShowFade(panelLevel, canvasGroupLevel, false);
    }
    public void OnDisablePanelLevel()
    {
        HideFade(panelLevel, canvasGroupLevel, false);
    }
    public void OnEnablePanelGuide()
    {
        ShowScale(panelGuide, panelGuide, false);
    }
    public void OnDisablePanelGuide()
    {
        HideScale(panelGuide, panelGuide, false);
    }

    public void ShowFade(GameObject panel, CanvasGroup canvasGroup, bool pause)
    {
        AnimUI.Instance.AnimFadeOut(canvasGroup, panel);
        if (pause)
        {
            GameManager.Instance.Pause();
        }
    }
    public void HideFade(GameObject panel, CanvasGroup canvasGroup, bool resume)
    {
        AnimUI.Instance.AnimFadeIn(canvasGroup, panel);
        if (resume)
        {
            GameManager.Instance.Play();
        }
    }
    void ShowScale(GameObject panel, GameObject popup, bool pause)
    {
        AnimUI.Instance.AnimScaleOut(popup, panel);
        if (pause)
        {
            GameManager.Instance.Pause();
        }
    }
    void HideScale(GameObject panel, GameObject popup, bool resume)
    {
        AnimUI.Instance.AnimScaleIn(popup, panel);
        if (resume)
        {
            GameManager.Instance.Play();
        }
    }
    public void AnimPanelLoading()
    {
        float time = Random.Range(0.7f, 1.5f);
        panelLoading.SetActive(true);
        DOVirtual.DelayedCall(time, () => panelLoading.SetActive(false));
    }
    public void SetOffAllPanel()
    {
        panelGamePlay.SetActive(false);
        panelPauseGame.SetActive(false);
        panelFinish.SetActive(false);
        panelLevel.SetActive(false);
        panelLoading.SetActive(false);
    }
    public void FinishChapter(int apple,int banana, int cherry, int stars)
    {
        OnEnablePanelFinish();
        _uiFinish.SetTextFinishPanel(apple, banana, cherry, stars);
    }
    public void SelectLevel()
    {
        OnDisablePanelLevel();
        OnEnablePanelGamePlay();
    }
    public void PressLevelMenu()
    {
        AnimPanelLoading();
        OnDisablePanelGamePlay();
        OnEnablePanelLevel();
    }
    public void LoadScene()
    {
        StartCoroutine(Scene.Instance.LoadSceneWithDelay(0, panelLoading));
    }
}

