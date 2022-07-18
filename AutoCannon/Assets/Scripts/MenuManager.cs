using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public Text highScoreText;
    int highScore;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "Highscore: " + highScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
