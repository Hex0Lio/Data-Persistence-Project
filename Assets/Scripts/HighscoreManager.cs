using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class HighscoreManager
{
    public static string playerName = "";
    public static string highscoreName;
    public static int highscore = -1;

    private static string Path => Application.persistentDataPath + "/savedata.json";

    public static void CompareScore(int score)
    {
        if (score > highscore) {
            highscore = score;
            highscoreName = playerName;
        }
    }

    public static void SaveScore()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Path, json);
    }

    public static void LoadScore()
    {
        
        if (File.Exists(Path)) {
            string json = File.ReadAllText(Path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highscoreName = data.highscoreName;
            highscore = data.highscore;
        }
    }

    [Serializable]
    private class SaveData
    {
        public string playerName;
        public string highscoreName;
        public int highscore;

        public SaveData()
        {
            playerName = HighscoreManager.playerName;
            highscoreName = HighscoreManager.highscoreName;
            highscore = HighscoreManager.highscore;
        }
    }
}
