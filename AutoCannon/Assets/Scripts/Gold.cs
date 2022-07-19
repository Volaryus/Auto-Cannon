using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = PlayerPrefs.GetInt("Gold");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddCoin(int amount)
    {
        gold += amount;
        PlayerPrefs.SetInt("Gold", gold);
    }

}
