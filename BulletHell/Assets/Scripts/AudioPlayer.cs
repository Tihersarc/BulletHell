using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private int deathIndex;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;

    private void Start()
    {
        MusicSlider.value = AudioManager.MusicVolume;
        SfxSlider.value = AudioManager.SfxVolume;
    }

    public void DeathSound()
    {
        AudioManager.PlaySound(deathIndex);
    }

    public void Play(string s)
    {
        AudioManager.Play(s);
    }

    public void Stop(string s)
    {
        AudioManager.Stop(s);
    }
}
