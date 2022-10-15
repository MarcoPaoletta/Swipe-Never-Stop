using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static float musicVolume;
    public AudioMixerGroup music;
    public static float soundEffectsVolume;
    public AudioMixerGroup soundEffects;

    void Start()
    {
        UpdateMixersValues();
    }

    void UpdateMixersValues()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        music.audioMixer.SetFloat("MusicVolume", musicVolume);
        soundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectsVolume");
        soundEffects.audioMixer.SetFloat("SoundEffectsVolume", soundEffectsVolume);
    }

    public static void PlayScoredAudio()
    {
        GameObject.Find("ScoredAudio").GetComponent<AudioSource>().Play();
    }

    public static void PlayGameOverAudio()
    {
        GameObject.Find("GameOverAudio").GetComponent<AudioSource>().Play();
    }

    public static void PlayTapToStartAudio()
    {
        GameObject.Find("TapToStartAudio").GetComponent<AudioSource>().Play();
    }
}
