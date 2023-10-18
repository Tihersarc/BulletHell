using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pauseMenu;
    private static PauseController pauseController;

    private void Awake()
    {
        if (pauseController == null)
        {
            pauseController = this;
        }
    }

    public static PauseController GetInstance()
    {
        return pauseController;
    }

    private void Start()
    {
        isPaused = false;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    }
}
