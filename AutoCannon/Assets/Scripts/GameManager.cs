using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    static int points = 0;
    static int highScore;
    static Text scoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        Application.targetFrameRate = 60;
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







    public Specials specials;
    public float timer = 60f;
    public float timeAmount = 30f;
    public Text timerText;
    public GameObject timeOverMenu;
    public AdsManager ads;
    public Gold gold;
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
            coinAmount = points / 2;

            //Time.timeScale = 0;
        }
    }

    public void PlayGame()
    {
        gold.AddCoin(coinAmount);
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        gold.AddCoin(coinAmount);
        SceneManager.LoadScene(0);
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
        // gold.AddCoin(coinAmount);
        coinAmount *= 2;
        //Debug.Log("Operation Success");
    }

    void TimeSetter()
    {
        timer = timeAmount;
        timeOverMenu.SetActive(false);
        isFinished = false;
    }

    public void AddTime()
    {
        if (specials.timeAdder > 0 && specials.timeCount > 0)
        {
            specials.AddTime();
            timer += 15;
        }
    }

    public void AddTriple(int amount, int price)
    {
        if (gold.gold >= price)
        {
            specials.BuyTriple(amount);
            gold.gold -= price;
        }
    }

    public void BuyTime(int amount, int price)
    {
        if (gold.gold >= price)
        {
            specials.BuyTime(amount);
            gold.gold -= price;
        }
    }
}
