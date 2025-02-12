using UnityEngine;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject panelGamePlay;
    [SerializeField] GameObject panelPauseGame;
    [SerializeField] GameObject panelFinish;
    [SerializeField] GameObject panelLevel;
    [SerializeField] GameObject panelLoading;
    [SerializeField] CanvasGroup canvasGroupGamePlay;
    [SerializeField] CanvasGroup canvasGroupPauseGame;
    [SerializeField] CanvasGroup canvasGroupFinish;
    [SerializeField] CanvasGroup canvasGroupLevel;
    [SerializeField] CanvasGroup canvasGroupLoading;
    [SerializeField] GameObject popupPause;
    public PanelGamePlay _uiGamePlay;
    public PanelFinish _uiFinish;
    public void StartUIManager()
    {
        SetOffAllPanel();
        panelLevel.SetActive(true);
    }
    public void OnEnablePanelGamePlay()
    {
        Show(panelGamePlay, canvasGroupGamePlay, false);
    }
    public void OnDisablePanelGamePlay()
    {
        Hide(panelGamePlay, canvasGroupGamePlay, false);
    }
    public void OnEnablePanelPauseGame()
    {
        Show(panelPauseGame, canvasGroupPauseGame, true);
        AnimScaleOn(popupPause);
    }
    public void OnDisablePanelPauseGame()
    {
        Hide(panelPauseGame, canvasGroupPauseGame, true);
        AnimScaleOff(popupPause);
    }
    public void OnEnablePanelFinish()
    {
        Show(panelFinish, canvasGroupFinish, false);
        AnimScaleOn(panelFinish);
    }
    public void OnDisablePanelFinish()
    {
        Hide(panelFinish, canvasGroupFinish, false);
        AnimScaleOff(panelFinish);
    }
    public void OnEnablePanelLevel()
    {
        Show(panelLevel, canvasGroupLevel, false);
        AnimScaleOn(panelLevel);
    }
    public void OnDisablePanelLevel()
    {
        Hide(panelLevel, canvasGroupLevel, false);
        AnimScaleOff(panelLevel);
    }
    public void OnEnablePanelLoading()
    {
        canvasGroupLoading.alpha = 0;
        panelLoading.SetActive(true);
        canvasGroupLoading.DOFade(1, 0.2f).SetUpdate(UpdateType.Normal, true);
    }
    public void OnDisablePanelLoading()
    {
        canvasGroupLoading.DOFade(0, 0.3f)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() => panelLoading.SetActive(false));
    }
    public void Show(GameObject panel, CanvasGroup canvasGroup, bool pause)
    {
        canvasGroup.alpha = 0;
        panel.SetActive(true);
        canvasGroup.DOFade(1, 0.5f).SetUpdate(UpdateType.Normal, true);
        if (pause)
        {
            GameManager.Instance.Pause();
        }
    }
    public void Hide(GameObject panel, CanvasGroup canvasGroup, bool resume)
    {
        canvasGroup.DOFade(0, 0.3f)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() => panel.SetActive(false));
        if (resume)
        {
            GameManager.Instance.Play();
        }
    }
    void AnimScaleOn(GameObject panel)
    {
        panel.transform.DOScale(Vector3.zero, 0).SetUpdate(UpdateType.Normal, true);
        panel.transform.DOScale(Vector3.one, 0.3f).SetUpdate(UpdateType.Normal, true);
    }
    void AnimScaleOff(GameObject panel)
    {
        panel.transform.DOScale(Vector3.zero, 0.2f).SetUpdate(UpdateType.Normal, true);
    }
    public void AnimPanelLoading()
    {
        float time = Random.Range(0.7f, 2f);
        OnEnablePanelLoading();
        DOVirtual.DelayedCall(time, () => OnDisablePanelLoading());
    }
    public void SetOffAllPanel()
    {
        panelGamePlay.SetActive(false);
        panelPauseGame.SetActive(false);
        panelFinish.SetActive(false);
        panelLevel.SetActive(false);
        panelLoading.SetActive(false);
    }
    public void FinishChapter(int coins, int stars)
    {
        OnEnablePanelFinish();
        _uiFinish.OnCoinsEnd(coins);
        _uiFinish.StarsUIEnd(stars);
    }
    public void SelectLevel()
    {
        AnimPanelLoading();
        OnDisablePanelLevel();
        OnEnablePanelGamePlay();
    }
    public void PressLevelMenu()
    {
        AnimPanelLoading();
        OnDisablePanelGamePlay();
        OnEnablePanelLevel();

    }
}

