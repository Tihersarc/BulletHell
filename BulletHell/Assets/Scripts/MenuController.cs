using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int sceneOnPlay;

    [SerializeField] private TMP_Text volumeTextValue;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume;

    //[Header("Levels")]
    //public string _newGameLevel;
    //private string _levelToLoad;

    private void Start()
    {
        //_volumeSlider.value = _defaultVolume;
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

    // Set volumetext
    public void VolumeSetSliderValue(float volume)
    {
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeReset()
    {
        volumeSlider.value = defaultVolume;
        volumeTextValue.text = defaultVolume.ToString("0.0");
    }
}
