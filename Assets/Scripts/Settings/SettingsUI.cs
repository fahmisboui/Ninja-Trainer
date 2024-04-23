using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _sfxSlider;
    [SerializeField] Toggle _musicToggle;
    [SerializeField] Toggle _sfxToggle;

    private void Start()
    {
        // update the UI with saved data in the playerPref
        _musicSlider.value = Settings.MusicVolumeChanged;
        _sfxSlider.value = Settings.SfxVolumeChanged;
        _musicToggle.isOn = Settings.MusicMuted;
        _sfxToggle.isOn = Settings.SfxMuted;
        AudioManager.instance.MusicVolume(_musicSlider.value);
        AudioManager.instance.SFXVolume(_sfxSlider.value);
        AudioManager.instance.MuteMusic(_musicToggle.isOn);
        AudioManager.instance.MuteSFX(_sfxToggle.isOn);


        // add UI listeners
        _musicSlider.onValueChanged.AddListener(OnVolumeMusicChange);
        _sfxSlider.onValueChanged.AddListener(OnVolumeSfxChange);
        _musicToggle.onValueChanged.AddListener(OnMusictoggle);
        _sfxToggle.onValueChanged.AddListener(OnSfxtoggle);
    }

    private void OnVolumeMusicChange(float value)
    {
        Settings.MusicVolumeChanged = value;
    }
    private void OnVolumeSfxChange(float value)
    {
        Settings.SfxVolumeChanged = value;
    }
    private void OnMusictoggle(bool value)
    {
        Settings.MusicMuted = value;
    } 
    private void OnSfxtoggle(bool value)
    {
        Settings.SfxMuted = value;
    }

}
