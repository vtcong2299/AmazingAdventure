using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimUI : Singleton<AnimUI>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void AnimFadeOut(CanvasGroup canvas, GameObject panel)
    {
        panel.SetActive(true);
        canvas.alpha = 0;
        canvas.DOFade(1, 0.5f).SetEase(Ease.InOutSine)
            .SetUpdate(UpdateType.Normal, true); 
    }
    public void AnimFadeIn(CanvasGroup canvas, GameObject panel)
    {
        canvas.alpha = 1;
        canvas.DOFade(0, 0.3f).SetEase(Ease.InOutSine)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() => panel.SetActive(false));
    }
    public void AnimScaleOut(GameObject popup, GameObject panel)
    {
        panel.SetActive(true);
        popup.transform.localScale = Vector3.zero;
        popup.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce)
            .SetUpdate(UpdateType.Normal, true);
    }
    public void AnimScaleIn(GameObject popup, GameObject panel)
    {
        popup.transform.localScale = Vector3.one;
        popup.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() => panel.SetActive(false));
    }
}
