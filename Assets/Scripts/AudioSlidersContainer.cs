using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlidersContainer : MonoBehaviour
{
    public AudioMixerGroup music;
    public AudioMixerGroup soundEffects;

    public Slider musicSlider;
    public Slider soundEffectsSlider;

    void Start()
    {
        musicSlider.value = AudioManager.musicVolume;
        soundEffectsSlider.value = AudioManager.soundEffectsVolume;
    }

    public void OnMusicSliderValueChanged(float value)
    {
        AudioManager.musicVolume = value;
        PlayerPrefs.SetFloat("MusicVolume", AudioManager.musicVolume);
        music.audioMixer.SetFloat("MusicVolume", AudioManager.musicVolume);
    }

    public void OnSoundEffectsSliderValueChanged(float value)
    {
        AudioManager.soundEffectsVolume = value;
        PlayerPrefs.SetFloat("SoundEffectsVolume", AudioManager.soundEffectsVolume);
        soundEffects.audioMixer.SetFloat("SoundEffectsVolume", AudioManager.soundEffectsVolume);
    }
}
