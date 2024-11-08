using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject panelStratGame;
    [SerializeField]
    private GameObject panelCharacter;
    public void Awake()
    {
        panelStratGame.SetActive(true);
        panelCharacter.SetActive(false);
    }
    public void PressPlay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
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
    }
    
    public void PressExit()
    {
        Application.Quit();
    }
}
