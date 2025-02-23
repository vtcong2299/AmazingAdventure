using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DataManager : Singleton<DataManager>
{
    public DataGamePlay dataGamePlay;
    public GameData gameData;
    [SerializeField] int idCharacter;
    [SerializeField] List<ConfigCharacter> dataCharacters = new List<ConfigCharacter>();
    [SerializeField] Sprite imageCharater;

    private void Start()
    {
        DontDestroyOnLoad(this);
        LoadData();
    }
    public void SaveData()
    {
        if (dataGamePlay != null)
        {
            dataGamePlay.SaveData(gameData);
        }
    }
    public void LoadData()
    {
        gameData = dataGamePlay.LoadData();
    }
    public void ResetData()
    {
        dataGamePlay.ResetData();
    }
    public void NextSelectCharacter()
    {
        idCharacter++;
        if (idCharacter == dataCharacters.Count)
        {
            idCharacter = 0;
        }
        CheckSelectCharaterPanel();
    }
    public void BackSelectCharacter()
    {
        idCharacter--;
        if (idCharacter == -1)
        {
            idCharacter = dataCharacters.Count - 1;
        }
        CheckSelectCharaterPanel();
    }
    public void UpdateSelectCharacter()
    {
        gameData.idPlayer = idCharacter;
        SaveData();        
    }
    public void CheckSelectCharaterPanel()
    {
        foreach (ConfigCharacter data in dataCharacters)
        {
            if (data.iD == idCharacter)
            {
                imageCharater = data.image;
                break;
            }
        }
        UIGameMenu.Instance.ChangeImageCharaterUI(imageCharater);
    }
    public void ShowCharacterSelecting()
    {
        idCharacter = gameData.idPlayer;
        CheckSelectCharaterPanel();
    }
    public void CheckInterfacePlayer()
    {
        PlayerCtrl.Instance.ninjaFrog.SetActive(false);
        PlayerCtrl.Instance.maskDude.SetActive(false);
        PlayerCtrl.Instance.pinkMan.SetActive(false);
        PlayerCtrl.Instance.virtualGuy.SetActive(false);
        switch (gameData.idPlayer)
        {
            case 0:
                {
                    PlayerCtrl.Instance.ninjaFrog.SetActive(true);
                    break;
                }
            case 1:
                {
                    PlayerCtrl.Instance.maskDude.SetActive(true);
                    break;
                }
            case 2:
                {
                    PlayerCtrl.Instance.pinkMan.SetActive(true);
                    break;
                }
            case 3:
                {
                    PlayerCtrl.Instance.virtualGuy.SetActive(true);
                    break;
                }
        }
    }    
    public void SetFPS()
    {
        Application.targetFrameRate = gameData.fps;
    }
}
