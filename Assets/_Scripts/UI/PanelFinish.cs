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
    public void SetTextFinishPanel(int apple, int banana, int cherry, int stars)
    {
        SetTxtComplete(apple, banana, cherry, stars);
        TxtAppleEnd(apple);
        TxtBananaEnd(banana);
        TxtCherryEnd(cherry);
        StarsUIEnd(stars);
    }
    public void SetTxtComplete(int apple, int banana,int cherry, int stars)
    {
        if (apple < LevelManager.Instance.targetApple || banana < LevelManager.Instance.targetBanana
            || cherry < LevelManager.Instance.targetCherry || stars == 0)
        {
            txtComplete.text = "Level Fail";
            lockNextButton.SetActive(true);
        }
        else
        {
            txtComplete.text = "Level Complete";
            lockNextButton.SetActive(false);
        }
    }
    public void TxtAppleEnd(int apple)
    {
        if (apple < LevelManager.Instance.targetApple)
        {
            txtAppleEnd.color = Color.red;
        }
        else
        {
            txtAppleEnd.color = Color.blue;
        }
        txtAppleEnd.text = apple + "/" + LevelManager.Instance.targetApple;
    }
    public void TxtBananaEnd(int banana)
    {
        if (banana < LevelManager.Instance.targetBanana)
        {
            txtBananaEnd.color = Color.red;
        }
        else
        {
            txtBananaEnd.color = Color.blue;
        }
        txtBananaEnd.text =banana + "/" + LevelManager.Instance.targetBanana;
    }
    public void TxtCherryEnd(int cherry)
    {
        if (cherry < LevelManager.Instance.targetBanana)
        {
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
