using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class PanelLevel : MonoBehaviour
{
    [SerializeField] Button level1Button;
    [SerializeField] Button level2Button;
    [SerializeField] Button level3Button;
    [SerializeField] Button backButton;
    private void Awake()
    {
        backButton.onClick.AddListener(ClickBackButton);
        level1Button.onClick.AddListener(PressLevel1);
        level2Button.onClick.AddListener(PressLevel2);
        level3Button.onClick.AddListener(PressLevel3);
    }
    void ClickBackButton()
    {
        UIManager.Instance.LoadScene();
    }
    public void PressLevel1()
    {
        UIManager.Instance.AnimPanelLoading();
        GameManager.Instance.SelectLevel(1);
    }
    public void PressLevel2()
    {
        UIManager.Instance.AnimPanelLoading();
        GameManager.Instance.SelectLevel(2);
    }    
    public void PressLevel3()
    {
        UIManager.Instance.AnimPanelLoading();
        GameManager.Instance.SelectLevel(3);
    }    
}
