using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public long gold;
    public List<int> hasItems;
    public List<int> hasUpgrades;

    public SaveData()
    {
        gold = 0;
        hasItems = new List<int>();
        hasUpgrades = new List<int>();
    }
}

/// <summary>
/// 로컬 데이터 저장 컨트롤러입니다.
/// 만약 서버 데이터 저장을 원하신다면 뒤끝 서버 SDK을 활용하는 것을 추천드립니다.
/// 세이브 파일 경로: {User}/AppData/LocalLow/{Company}
/// </summary>
public class SaveManager : MonoBehaviour
{
    private SaveData saveData;
    public SaveData SaveData
    {
        get
        {
            if (saveData == null)
                Debug.LogError("Error! SaveData is NULL!");
            return saveData;
        }
    }

    private string savePath;

    public void Init()
    {
        saveData = new SaveData();
        savePath = Path.Combine(Application.persistentDataPath, "SaveData.json");

        LoadGame();
    }

    public void SaveGame()
    {
        string _saveJson = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, _saveJson);
    }

    public void LoadGame()
    {
        if (!CheckSaveFile())
        {
            Debug.Log("SaveData is not exised! So system creats a new SaveData.");
            SaveGame();
            return;
        }

        string _loadJson = File.ReadAllText(savePath);
        saveData = JsonUtility.FromJson<SaveData>(_loadJson);
    }

    private bool CheckSaveFile() => File.Exists(Path.Combine(Application.persistentDataPath, "SaveData.json"));
}
