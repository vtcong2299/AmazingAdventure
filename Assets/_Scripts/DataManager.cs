using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public DataGamePlay dataGamePlay;
    public GameData gameData; 
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
}
