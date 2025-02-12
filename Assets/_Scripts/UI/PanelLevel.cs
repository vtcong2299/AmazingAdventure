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
    [SerializeField] Button backButton;
    private void Awake()
    {
        backButton.onClick.AddListener(ClickBackButton);
        level1Button.onClick.AddListener(PressLevel1);
        level2Button.onClick.AddListener(PressLevel2);
    }
    void ClickBackButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PressLevel1()
    {
        GameManager.Instance.SelectLevel(1);
    }
    public void PressLevel2()
    {
        GameManager.Instance.SelectLevel(2);
    }    
}
