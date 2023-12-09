using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    AudioClip currentClip;
    public AudioClip defaultThud;

    float baseVolume;
    float currentVolume;
    [SerializeField]
    float m_volumeMultiplier = 0.3f;
    public float volumeMultiplier
    {
        get { return m_volumeMultiplier; }

        set
        {
            m_volumeMultiplier = value;
            audioSource.volume = baseVolume * m_volumeMultiplier;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeVolume(float newVolumeMultiplier)
    {
        volumeMultiplier = newVolumeMultiplier;

        currentVolume = volumeMultiplier * baseVolume;

        audioSource.volume = currentVolume;
    }

    public void PlaySoundEffect(AudioClip soundEffect, float volume = 1f)
    {
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect, volume);
        }
    }
}