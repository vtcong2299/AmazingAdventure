using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject panelLevel;
    public GameObject panelStratGame;
    public GameObject panelCharacter;
    public void Start()
    {
        PressBack();
    }
    public void PressPlay()
    {
        panelLevel.SetActive(true);
        panelStratGame.SetActive(false);
    }
    public void PressOptions()
    {
        panelCharacter.SetActive(true);
        panelStratGame.SetActive(false) ;   
    }
    public void PressBack()
    {
        panelStratGame.SetActive(true);
        panelCharacter.SetActive(false);
        panelLevel.SetActive(false);
    }
    public void PressLevel1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;  
    }
    public void PressExit()
    {
        Application.Quit();
    }
}
