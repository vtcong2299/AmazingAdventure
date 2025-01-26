
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject panelGamePlay;
    [SerializeField] GameObject panelPauseGame;
    [SerializeField] GameObject panelFinish;
    [SerializeField] GameObject panelLevel;
    [SerializeField] CanvasGroup canvasGroupGamePlay;
    [SerializeField] CanvasGroup canvasGroupPauseGame;
    [SerializeField] CanvasGroup canvasGroupFinish;
    [SerializeField] CanvasGroup canvasGroupLevel;
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
        AnimScaleOn(panelPauseGame);
    }
    public void OnDisablePanelPauseGame()
    {
        Hide(panelPauseGame, canvasGroupPauseGame, true);
        AnimScaleOff(panelPauseGame);
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
        Show(panelLevel, canvasGroupLevel, true);
        AnimScaleOn(panelLevel);
    }
    public void OnDisablePanelLevel()
    {
        Hide(panelLevel, canvasGroupLevel, true);
        AnimScaleOff(panelLevel);
    }
    public void LoadScene(string sceneName)
    {
        //panelLoadScene.gameObject.SetActive(true);
        //panelLoadScene.SetSceneName(sceneName);
    }

    public void Show(GameObject panel, CanvasGroup canvasGroup, bool pause)
    {
        canvasGroup.alpha = 0;
        panel.SetActive(true);
        canvasGroup.DOFade(1, 0.5f).SetUpdate(UpdateType.Normal, true);
        if (pause)
        {
            //GameManager.Instance.SetGameState(GameState.Pause);
        }
    }
    public void Hide(GameObject panel, CanvasGroup canvasGroup, bool resume)
    {
        canvasGroup.DOFade(0, 0.3f)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() => DisablePanel(panel));
        if (resume)
        {
            //GameManager.Instance.SetGameState(GameState.Running);
        }
    }
    void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
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
}

