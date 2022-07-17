using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += ModeChanged;
#endif
        if (HighscoreManager.highscore == -1) HighscoreManager.LoadScore();
        if (HighscoreManager.playerName.Length != 0) nameInput.text = HighscoreManager.playerName;
        if (HighscoreManager.highscore == -1) highscoreText.text = "";
        else highscoreText.text = $"Best Score: {HighscoreManager.highscoreName} : {HighscoreManager.highscore}";
    }
#if UNITY_EDITOR
    void ModeChanged(PlayModeStateChange change)
    {
        if (change == PlayModeStateChange.ExitingPlayMode) HighscoreManager.SaveScore();
    }
#else
    private void OnApplicationQuit()
    {
        HighscoreManager.SaveScore();
    }
#endif

    public void SetName()
    {
        HighscoreManager.playerName = nameInput.text;
    }

    public void StartGame()
    {
        if (HighscoreManager.playerName.Length != 0) SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
