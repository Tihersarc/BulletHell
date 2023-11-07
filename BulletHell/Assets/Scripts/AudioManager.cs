using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundList;

    private static AudioManager Instance;
    private static List<AudioClip> audioList;

    //[SerializeField]
    //private Slider volumeSlider;

    public void Start()
    {
        Instance = this;
        audioList = new List<AudioClip>();

        for (int i = 0; i < soundList.Length; i++) {
            audioList.Add(soundList[i]);
        }

    }
    public static void PlaySound(int soundNumber)
    {
        Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(audioList[soundNumber]);
    }

    //public void Slider()
    //{
    //    float volume = volumeSlider.value;
    //    AudioListener.volume = volume;
    //}
}
