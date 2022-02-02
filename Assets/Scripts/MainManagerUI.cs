using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManagerUI : MonoBehaviour
{
    public static MainManagerUI Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore;
    }

    public void Start()
    {
        LoadGameData();
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}