using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int score;
    public GameObject triggerEffect;
    public AudioSource audioSource;
    public AudioClip hitClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameManager.AddScore(score);
            GameObject effect = Instantiate(triggerEffect);
            audioSource.PlayOneShot(hitClip);
            Destroy(effect, 0.3f);
            gameObject.SetActive(false);
        }
    }
}
