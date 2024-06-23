using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_effect : MonoBehaviour
{
    public float start_time = 0;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = start_time;
        audioSource.Play();
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        } 
    }
}
