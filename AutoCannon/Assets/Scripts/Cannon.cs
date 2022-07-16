using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float yLimit = 75f;
    public float turnSpeed = 15f;
    bool turnRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (turnRight)
        {
            transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
            if (transform.rotation.eulerAngles.z >= yLimit - 5)
            {
                turnRight = !turnRight;
            }
        }
        else
        {
            transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
            if (transform.rotation.eulerAngles.z >= 360 - yLimit)
            {
                turnRight = !turnRight;
            }
        }
        Debug.Log(turnRight);
       // Debug.Log(transform.rotation.eulerAngles.z);
    }
}
