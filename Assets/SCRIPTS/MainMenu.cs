using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highScoreUI;
    string newGameScene = "SampleScene";
    public AudioClip bg_music;
    public AudioSource main_channel;


    void Start()
    {
        main_channel.PlayOneShot(bg_music);
        //set the high score text
        int highScore = SaveLoadManager.Instance.LoadHighScore();
        highScoreUI.text = $"Top Wave Survived: {highScore}";
    }

    public void StartNewGame()
    {
        main_channel.Stop();
        SceneManager.LoadScene(newGameScene);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; //so we can test if it working inside the editor
#else
    Application.Quit();
#endif


    }

}
