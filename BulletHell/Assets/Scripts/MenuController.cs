using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int _sceneOnPlay;

    [SerializeField] private TMP_Text _volumeTextValue;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _defaultVolume;

    //[Header("Levels")]
    //public string _newGameLevel;
    //private string _levelToLoad;

    private void Start()
    {
        //_volumeSlider.value = _defaultVolume;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneOnPlay); 
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
        _volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeReset()
    {
        _volumeSlider.value = _defaultVolume;
        _volumeTextValue.text = _defaultVolume.ToString("0.0");
    }
}
