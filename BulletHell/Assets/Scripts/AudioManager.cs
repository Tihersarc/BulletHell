using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManager;
    public static AudioManager instance
    {
        get { return audioManager; }
    }

    // Replace with new system
    private static List<AudioClip> audioList;
    [SerializeField] private AudioClip[] soundList;

    public static float musicVolume {  get; private set; }
    public static float sfxVolume { get; private set; }
    
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private Sound[] sounds;

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

        audioList = new List<AudioClip>();

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

        for (int i = 0; i < soundList.Length; i++) {
            audioList.Add(soundList[i]);
        }
    }

    public static void PlaySound(int soundNumber)
    {
        audioManager.gameObject.GetComponent<AudioSource>().PlayOneShot(audioList[soundNumber]);
    }

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void OnSfxSliderValueChange(float value)
    {
        sfxVolume = value;
        sfxGroup.audioMixer.SetFloat("SfxVolume", Mathf.Log10(value)*20);
    }
}
