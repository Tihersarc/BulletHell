using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int sceneOnPlay;

    [SerializeField] private TMP_Text volumeTextValue;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private float defaultVolume;

    private void Start()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSfxVolume();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneOnPlay); 
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void OnMusicSliderValueChange(float val)
    {
        AudioManager.Instance.OnMusicSliderValueChange(val);
    }

    public void OnSfxSliderValueChange(float val)
    {
        AudioManager.Instance.OnSfxSliderValueChange(val);
    }

    public void VolumeSetSliderValue(float volume)
    {
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeReset()
    {
        musicSlider.value = defaultVolume;
        sfxSlider.value = defaultVolume;
    }
}
