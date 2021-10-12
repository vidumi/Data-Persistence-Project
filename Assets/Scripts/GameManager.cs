using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentPlayerName;
    public string bestPlayerName;
    public string bestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
       // Debug.Log(Application.persistentDataPath);
    }

    [System.Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public string bestPlayerName;
        public string bestScore;
    }
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentPlayerName = data.currentPlayerName;
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}
