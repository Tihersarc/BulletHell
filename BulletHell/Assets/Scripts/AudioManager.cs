using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManager;

    public static AudioManager Instance
    {
        get { return audioManager; }
    }

    public static float MusicVolume {  get; private set; }
    public static float SfxVolume { get; private set; }
    
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private List<Sound> sounds;
    private static List<Sound> soundList;

    public void Awake()
    {

        if (audioManager != null)
        {
            Destroy(this);
        }
        else
        {
            audioManager = this;
        }
        DontDestroyOnLoad(audioManager.gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.loop = s.isLoop;
            s.source.volume = s.volume;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = sfxGroup;
                    break;

                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicGroup;
                    break;
            }

            if (s.playOnAwake)
            {
                s.source.Play();
            }
        }

        soundList = new List<Sound>();
        for (int i = 0; i < sounds.Count; i++)
        {
            soundList.Add(sounds[i]);
        }
    }

    public static void PlaySound(int soundNumber)
    {
        audioManager.gameObject.GetComponent<AudioSource>().PlayOneShot(soundList.ElementAt(soundNumber).audioClip);
    }

    public static void Play(string clipname)
    {
        Sound s = soundList.Find(sound => sound.clipName == clipname);
        //Array.Find(soundList, dummySound => dummySound.clipName == clipname);

        if (s == null)
        {
            Debug.LogError("Sound: " + clipname + " does NOT exist!");
        }
        else
        {
            s.source.Play();
            Debug.Log("Sound: " + clipname + " now playing.");
        }
    }

    public static void Stop(string clipname)
    {
        Sound s = soundList.Find(sound => sound.clipName == clipname);

        if (s == null)
        {
            Debug.LogError("Sound: " + clipname + " does NOT exist!");
            return;
        }
        else
        {
            Debug.Log("Sound: " + clipname + " stopped playing.");
            s.source.Stop();
        }
    }

    public void OnMusicSliderValueChange(float value)
    {
        MusicVolume = value;
        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void OnSfxSliderValueChange(float value)
    {
        SfxVolume = value;
        sfxGroup.audioMixer.SetFloat("SfxVolume", Mathf.Log10(value) * 20);
    }

    public float GetMusicVolume()
    {
        sfxGroup.audioMixer.GetFloat("MusicVolume", out float value);
        value = Mathf.Pow(10, value / 20);

        return value;
    }

    public float GetSfxVolume()
    {
        sfxGroup.audioMixer.GetFloat("SfxVolume", out float value);
        value = Mathf.Pow(10, value / 20);

        return value;
    }
}
