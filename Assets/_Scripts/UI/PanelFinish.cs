using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class PanelFinish : MonoBehaviour
{
    public GameObject[] listStarsUIEnd;
    [SerializeField] Text txtAppleEnd;
    [SerializeField] Text txtBananaEnd;
    [SerializeField] Text txtCherryEnd;
    [SerializeField] Text txtComplete;
    [SerializeField] Button replayButton;
    [SerializeField] Button homeButton;
    [SerializeField] Button levelButton;
    [SerializeField] Button nextLevelButton;
    [SerializeField] GameObject lockNextButton;
    private void Awake()
    {
        replayButton.onClick.AddListener(ClickRePlayButton);
        homeButton.onClick.AddListener(ClickHomeButton);
        levelButton.onClick.AddListener(PressLevelMenu);
        nextLevelButton.onClick.AddListener(PressNextLevel);
    }
    private void OnEnable()
    {
        lockNextButton.SetActive(false);
    }
    public void SetTxtComplete(int apple, int banana,int cherry, int stars)
    {
        if (apple < LevelManager.Instance.targetApple || banana < LevelManager.Instance.targetBanana
            || cherry < LevelManager.Instance.targetCherry || stars == 0)
        {
            txtComplete.text = "Level Fail";
        }
        else
        {
            txtComplete.text = "Level Compelete";
        }
    }
    public void OnAppleEnd(int apple)
    {
        if (apple < LevelManager.Instance.targetApple)
        {
            lockNextButton.SetActive(true);
            txtAppleEnd.color = Color.red;
        }
        else
        {
            txtAppleEnd.color = Color.blue;
        }
        txtAppleEnd.text = apple + "/" + LevelManager.Instance.targetApple;
    }
    public void OnBananaEnd(int banana)
    {
        if (banana < LevelManager.Instance.targetBanana)
        {
            lockNextButton.SetActive(true);
            txtBananaEnd.color = Color.red;
        }
        else
        {
            txtBananaEnd.color = Color.blue;
        }
        txtBananaEnd.text =banana + "/" + LevelManager.Instance.targetBanana;
    }
    public void OnCherryEnd(int cherry)
    {
        if (cherry < LevelManager.Instance.targetBanana)
        {
            lockNextButton.SetActive(true);
            txtCherryEnd.color = Color.red;
        }
        else
        {
            txtCherryEnd.color = Color.blue;
        }
        txtCherryEnd.text = cherry + "/" + LevelManager.Instance.targetCherry;
    }
    public void StarsUIEnd(int stars)
    {
        if (stars == 0)
        {
            lockNextButton.SetActive(true);
        }
        for (int i = 0; i < stars; i++)
        {
            listStarsUIEnd[i].SetActive(true);
        }
        for (int i = stars; i < 3; i++)
        {
            listStarsUIEnd[i].SetActive(false);
        }
    }
    void SelectLevel()
    {
        GameManager.Instance.NextLevel();
    }
    public void PressNextLevel()
    {
        AudioManager.Instance.SoundClickButton();
        UIManager.Instance.AnimPanelLoading();
        GameManager.Instance.UnLoadLevel();
        UIManager.Instance.OnDisablePanelFinish();
        Invoke("SelectLevel", 0.3f);
    }   
    public void PressLevelMenu()
    {
        AudioManager.Instance.SoundClickButton();
        UIManager.Instance.PressLevelMenu();
        UIManager.Instance.OnDisablePanelFinish();
        GameManager.Instance.UnLoadLevel();
    }
    public void ClickRePlayButton()
    {
        AudioManager.Instance.SoundClickButton();
        PlayerCtrl.Instance.BackCheckPoint();
        UIManager.Instance.OnDisablePanelFinish();
    }
    public void ClickHomeButton()
    {
        AudioManager.Instance.SoundClickButton();
        UIManager.Instance.OnDisablePanelFinish();
        UIManager.Instance.LoadScene();
    }
}
