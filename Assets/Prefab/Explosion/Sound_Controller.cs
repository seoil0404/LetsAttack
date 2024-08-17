using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller : MonoBehaviour
{
    public AudioClip[] BombAudioArr;

    public void BombSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = BombAudioArr[Random.Range(0, BombAudioArr.Length)];
        audioSource.time = 0.65f;
        audioSource.Play();
    }
}
