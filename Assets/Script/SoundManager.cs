using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Find and Playes sound for special effect and background music
/// </summary>

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource SoundSFx;
    public AudioSource SoundBgMusic;

    public Soundtype[] Sounds;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlaySoundBgMusic("BgMusic");
    }

    // Plays Background music
    public void PlaySoundBgMusic(string soundName)
    {
        AudioClip clip = getAudioClip(soundName);
        if (clip != null)
        {
            SoundBgMusic.clip = clip;
            SoundBgMusic.Play();
        }
        else
        {
            return;
        }

    }

    // Plays Special effect sound
    public void PlaySFx(string soundName)
    {
        AudioClip clip = getAudioClip(soundName);
        if(clip != null)
        {
            SoundSFx.PlayOneShot(clip);
        }
        else
        {
            return;
        }

    }

    // return corresponding AudioClip
    public AudioClip getAudioClip(string soundName)
    {
        Soundtype Soundname = Array.Find(Sounds, item => item.soundClipName == soundName);
        if(Soundname != null)
        {
            return Soundname.soundClip;
        }
        else
        {
            return null;
        }
    }


}

[Serializable]
public class Soundtype
{
    public string soundClipName;
    public AudioClip soundClip;
}


