using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGuide : MonoBehaviour
{
    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(ClickBackButton);
    }
    void ClickBackButton()
    {
        AudioManager.Instance.SoundClickButton();
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() => transform.gameObject.SetActive(false));
    }
}
