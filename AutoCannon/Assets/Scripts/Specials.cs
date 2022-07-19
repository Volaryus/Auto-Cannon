using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specials : MonoBehaviour
{
    [SerializeField]
    Cannon cannon;
    public int tripleShot;
    bool tripleUsed = false;
    public int timeAdder;
    public int timeCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        tripleShot = PlayerPrefs.GetInt("tripleShot");
        timeAdder = PlayerPrefs.GetInt("timeAdder");
    }

    public void TripleShot()
    {
        if (tripleShot > 0 && !tripleUsed)
        {
            tripleUsed = true;
            tripleShot--;
            PlayerPrefs.SetInt("tripleShot", tripleShot);
            cannon.shotTriple = true;
        }
    }
    public void AddTime()
    {
            timeAdder--;
            timeCount--;
            PlayerPrefs.SetInt("timeAdder", timeAdder);
    }

}
