using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private int deathSoundIndex;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;

    private void Start()
    {
        MusicSlider.value = AudioManager.MusicVolume;
        SfxSlider.value = AudioManager.SfxVolume;
    }

    public void DeathSound()
    {
        AudioManager.PlaySound(deathSoundIndex);
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
