using UnityEngine;
using UnityEngine.Events;

public static class Settings 
{
    // private fields to hold data
    private static float _musicVolumeChanged;
    private static float _sfxVolumeChanged;
    private static bool _musicMuted;
    private static bool _sfxMuted;

    // settings events
    public static UnityAction<float> OnMusicVolumeChanged;
    public static UnityAction<float> OnSfxVolumeChanged;
    public static UnityAction<bool> OnMusicMuted;
    public static UnityAction<bool> OnSfxMuted;

    // public properties
    public static float MusicVolumeChanged
    {
        get{ return _musicVolumeChanged; }
        set{
            _musicVolumeChanged = value;
            PlayerPrefs.SetFloat("MusicVolumeChanged", value);
            if (OnMusicVolumeChanged != null)
            {
                OnMusicVolumeChanged.Invoke(value);
            }
           }
    }
    public static float SfxVolumeChanged
    {
        get { return _sfxVolumeChanged; }
        set
        {
            _sfxVolumeChanged = value;
            PlayerPrefs.SetFloat("SfxVolumeChanged", value);
            if (OnSfxVolumeChanged != null)
            {
                OnSfxVolumeChanged.Invoke(value);
            }
        }
    }
    public static bool MusicMuted
    {
        get { return _musicMuted; }
        set
        {
            _musicMuted = value;
            PlayerPrefs.SetInt("MusicMuted", (value ? 1 : 0));
            if (OnMusicMuted != null)
            {
                OnMusicMuted.Invoke(value);
            }
        }
    }
    public static bool SfxMuted
    {
        get { return _sfxMuted; }
        set
        {
            _sfxMuted = value;
            PlayerPrefs.SetInt("SfxMuted", (value ? 1 : 0));
            if (OnSfxMuted != null)
            {
                OnSfxMuted.Invoke(value);
            }
        }
    }

    // get saved data
    static Settings()
    {
        _musicVolumeChanged = PlayerPrefs.GetFloat("MusicVolumeChanged", 1);
        _sfxVolumeChanged = PlayerPrefs.GetFloat("SfxVolumeChanged", 1);
        _musicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        _sfxMuted = PlayerPrefs.GetInt("SfxMuted", 0) == 1;
    }
}
