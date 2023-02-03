using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> sounds = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = sounds[Random.Range(0, sounds.Count)];
            audioSource.Play();

            //play the sound at faster rate
            audioSource.pitch = Random.Range(1.5f, 2f);

            audioSource.volume = 0.4f;
            


        }
    }
}
