using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float yLimit = 75f;
    public float turnSpeed = 15f;
    bool turnRight = true;

    [SerializeField]
    private GameObject ball;
    public float shootSpeed = 15f;
    public Transform[] shootPoint;
    bool canShot = true;
    public bool shotTriple = false;
    float tripleShotCounter=15f;
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
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShot)
        {
            Shoot();
        }
#else
        if (Input.touchCount > 0 && canShot)
        {
            Shoot();
        }
#endif
        if(shotTriple)
        {

        }
        Debug.Log(turnRight);
        // Debug.Log(transform.rotation.eulerAngles.z);
    }

    void Shoot()
    {
        if (!shotTriple)
        {
            GameObject shootedBall = Instantiate(ball, shootPoint[0].position, shootPoint[0].rotation);
            Rigidbody ballRb = shootedBall.GetComponent<Rigidbody>();
            ballRb.velocity = shootPoint[0].forward * shootSpeed;
           // ballRb.AddRelativeForce(shootPoint[0].forward * shootSpeed, ForceMode.Impulse);
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject shootedBall = Instantiate(ball, shootPoint[i].position, shootPoint[i].rotation);
                Rigidbody ballRb = shootedBall.GetComponent<Rigidbody>();
                ballRb.velocity = shootPoint[i].forward * shootSpeed;
                //ballRb.AddRelativeForce(shootPoint[i].forward * shootSpeed, ForceMode.Impulse);
            }
        }
        canShot = false;
        Invoke("RepeatShot", 2f);
    }
    void RepeatShot()
    {
        canShot = true;
    }
}
