using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif
using System.IO;

public static class HighscoreManager
{
    public static string playerName = "";
    public static string highscoreName;
    public static int highscore = -1;

    private static string Path => Application.persistentDataPath + "/savedata.json";

//#if UNITY_EDITOR
//    static HighscoreManager()
//    {
//        EditorApplication.playModeStateChanged += ModeChanged;
//    }

//    static void ModeChanged(PlayModeStateChange change)
//    {
//        if (change == PlayModeStateChange.ExitingPlayMode) SaveScore();
//    }
//#endif

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
