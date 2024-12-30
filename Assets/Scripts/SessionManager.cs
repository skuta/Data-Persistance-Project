using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using TMPro;

public class SessionManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SessionManager Instance;
    private static String playerNameBestScore ="Nobody";
    public static String currentPlayerName = "Player";
    private static int topScore { get; set; } = 0;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave();
    }

    //Load Save from JSON file
    [Serializable]
    class SaveData
    {
        public string playerNameBestScore;
        public int topScore;

    }

    public String GetBestPlayerName()
    {
        return playerNameBestScore;
    }

    public void SetBestPlayerName(String playername)
    {
        playerNameBestScore = playername;
    }

    public int GetTopScore()
    {
       
        return topScore;

    }

    public void SetTopScore(int score)
    {
        topScore = score;
    }

    public String GetActivePlayerName()
    {
        return currentPlayerName;
    }

    public void SetActivePlayerName(String playername)
    {
        currentPlayerName = playername;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerNameBestScore = playerNameBestScore;
        data.topScore = topScore;

        string json = JsonUtility.ToJson(data);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
    }

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameBestScore = data.playerNameBestScore;
            topScore = data.topScore;
        }
    }
}