using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shooting, destroying, winning, losing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void ShootingSound()
    {
        audioSource.PlayOneShot(shooting);
    }

    public void DestroyingSound()
    {
        audioSource.PlayOneShot(destroying);
    }
    public void WinningSound()
    {
        audioSource.PlayOneShot(winning);
    }
    public void LosingSound()
    {
        audioSource.PlayOneShot(losing);
    }
}
