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

    public void OnMusicSliderValueChange(float val)
    {
        AudioManager.Instance.OnMusicSliderValueChange(val);
    }

    public void OnSfxSliderValueChange(float val)
    {
        AudioManager.Instance.OnSfxSliderValueChange(val);
    }
}
