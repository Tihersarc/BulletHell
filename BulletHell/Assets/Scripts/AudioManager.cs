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

    //private static List<Sound> soundList;
    //[SerializeField] private AudioClip[] soundList;

    public static float MusicVolume {  get; private set; }
    public static float SfxVolume { get; private set; }
    
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private Sound[] sounds;
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

        //soundList = new List<AudioClip>();

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
        for (int i = 0; i < sounds.Length; i++)
        {
            soundList.Add(sounds[i]);
        }
    }

    public static void PlaySound(int soundNumber)
    {
        audioManager.gameObject.GetComponent<AudioSource>().PlayOneShot(soundList.ElementAt(soundNumber).audioClip);
    }

    public void OnMusicSliderValueChange(float value)
    {
        MusicVolume = value;
        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void OnSfxSliderValueChange(float value)
    {
        SfxVolume = value;
        sfxGroup.audioMixer.SetFloat("SfxVolume", Mathf.Log10(value)*20);
    }
}
