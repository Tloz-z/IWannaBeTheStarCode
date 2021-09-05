using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager instance;

    private AudioSource audioSource;

    public AudioClip jump;

    private bool isActive = true;

    public static EffectManager getInstance()
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

        DontDestroyOnLoad(gameObject);

    }


    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
        audioSource.loop = false;
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    public void ToggleEffect()
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
