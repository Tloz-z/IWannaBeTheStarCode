using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    private AudioSource audioSource;

    public AudioClip defaultBGM;
    public AudioClip clearBGM;


    private bool isActive = true;
    public static BGMManager getInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = true;
        DontDestroyOnLoad(gameObject);
    }


    public void PlaySound(AudioClip audio)
    {
        audioSource.Stop();
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    public void ToggleBGM()
    {
        if (isActive)
        {
            audioSource.volume = 0;
            isActive = false;
        }
        else
        {
            audioSource.volume = 1;
            isActive = true;
        }
    }

}