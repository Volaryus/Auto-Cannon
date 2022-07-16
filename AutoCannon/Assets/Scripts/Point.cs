using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int pointAmount = 3;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.points += pointAmount;
    }
}
