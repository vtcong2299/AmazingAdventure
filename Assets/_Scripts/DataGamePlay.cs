using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;
using System.ComponentModel;

[Serializable]
public class GameData
{
    public bool hasBGM;
    public bool hasSFX;
}

public class DataGamePlay : MonoBehaviour
{
    private string dataPath;

    public void StartDataGamePlay()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "playerData.json");
        LoadData(); //load khi khởi động
    }

    public void SaveData(GameData data)
    {
        string json = JsonUtility.ToJson(data); //chuyển data thành chuỗi json
        File.WriteAllText(dataPath, json); //tạo file nếu chưa tồn tại
    }

    public GameData LoadData()
    {
        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        return new GameData(); // Trả về dữ liệu mới nếu không tìm thấy file
    }
}
