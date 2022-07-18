using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    static int points = 0;
    static int highScore;
    static Text scoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");

    }

    public static void AddScore(int number)
    {
        points += number;
        scoreText.text = "Score: " + points;
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }








    public float timer = 60f;
    public float timeAmount = 30f;
    public Text timerText;
    public GameObject timeOverMenu;
    public AdsManager ads;

    int coinAmount;
    bool isFinished = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time: " + (int)timer;
        if (timer <= 0 && !isFinished)
        {
            isFinished = true;
            timeOverMenu.SetActive(true);
            timer = 0;


            //Time.timeScale = 0;
        }
    }

    public void PlayGame()
    {

    }
    public void ReturnMenu()
    {

    }

    public void DoubleCoin()
    {
        ads.PlayRewardedAd(MultiplyCoin);
    }

    public void SetTime()
    {
        ads.PlayRewardedAd(TimeSetter);
    }
    void MultiplyCoin()
    {
        //gold.GetCoin(coinAmount);
        //coinAmount *= 2;
        //Debug.Log("Operation Success");
    }

    void TimeSetter()
    {
        timer = timeAmount;
        timeOverMenu.SetActive(false);
        isFinished = false;
    }
}
