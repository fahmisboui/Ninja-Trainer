using System;
using System.Xml.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

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

    void Start()
    {
        Settings.OnMusicVolumeChanged += MusicVolume;
        Settings.OnSfxVolumeChanged += SFXVolume;
        Settings.OnMusicMuted += MuteMusic;
        Settings.OnSfxMuted += MuteSFX;

        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogError("Music not found");
            return;
        }
        musicSource.clip = s.Clip;
        musicSource.Play();      
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogError("SFX Sound not found");
            return;
        }
        sfxSource.PlayOneShot(s.Clip);
    }

    public void MuteMusic(bool mute)
    {
        musicSource.mute = mute;
    }

    public void MuteSFX(bool mute)
    {
        sfxSource.mute = mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
