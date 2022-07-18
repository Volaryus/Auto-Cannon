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
    public Transform shootPoint;
    bool canShot = true;
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
        if(Input.GetKeyDown(KeyCode.Mouse0)&&canShot)
        {
            Shoot();
        }
#else
        if (Input.touchCount > 0 && canShot)
        {
            Shoot();
        }
#endif
        Debug.Log(turnRight);
        // Debug.Log(transform.rotation.eulerAngles.z);
    }

    void Shoot()
    {
        GameObject shootedBall = Instantiate(ball, shootPoint.position, shootPoint.rotation);
        Rigidbody ballRb = shootedBall.GetComponent<Rigidbody>();
        ballRb.velocity = shootPoint.forward * shootSpeed*Time.deltaTime;
        //ballRb.AddRelativeForce(0, 0, shootSpeed, ForceMode.Impulse);
        canShot = false;
        Invoke("RepeatShot", 2f);
    }
    void RepeatShot()
    {
        canShot = true;
    }
}
