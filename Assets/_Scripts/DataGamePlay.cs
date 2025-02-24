using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public bool hasBGM = true;
    public bool hasSFX = true;
    public List<int> idMapCompeleteOneStar = new List<int>();
    public List<int> idMapCompeleteTwoStar = new List<int>();
    public List<int> idMapCompeleteThreeStar = new List<int>();
    public int idMapCompeleteMax = 0;
    public int idPlayer = 0;
    public int fps = 45;
    public bool isPlayOnMobile;
}


public class DataGamePlay : MonoBehaviour
{
    private const string GameDataKey = "GameData";
    //private string dataPath;

    private void Start()
    {
        //dataPath = Path.Combine(Application.persistentDataPath, "playerData.json");
        LoadData(); // Load khi khởi động
    }

    public void SaveData(GameData data)
    {
        string json = JsonUtility.ToJson(data); // Chuyển data thành chuỗi JSON
        PlayerPrefs.SetString(GameDataKey, json); // Lưu chuỗi JSON vào PlayerPrefs
        PlayerPrefs.Save(); // Lưu ngay lập tức

        // Lưu dữ liệu vào file hệ thống
        //File.WriteAllText(dataPath, json);
    }

    public GameData LoadData()
    {
        if (PlayerPrefs.HasKey(GameDataKey))
        {
            string json = PlayerPrefs.GetString(GameDataKey);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        //else if (File.Exists(dataPath))
        //{
        //    string json = File.ReadAllText(dataPath);
        //    GameData data = JsonUtility.FromJson<GameData>(json);
        //    return data;
        //}
        return new GameData(); // Trả về dữ liệu mới nếu không tìm thấy dữ liệu
    }

    public void ResetData()
    {
        if (PlayerPrefs.HasKey(GameDataKey))
        {
            PlayerPrefs.DeleteKey(GameDataKey);
        }

        //if (File.Exists(dataPath))
        //{
        //    File.Delete(dataPath);
        //}
    }
}
