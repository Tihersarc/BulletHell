using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnLevelFinish;
    public UnityEvent OnLevelFail;

    private static GameController gameController;
    public static GameController Instance
    {
        get { return gameController; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            gameController = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void LevelFinished()
    {
        OnLevelFinish.Invoke();
        Debug.Log("Level Finished");
    }

    public void LevelFailed()
    {
        OnLevelFail.Invoke();
        Debug.Log("Level Failed");
    }
}
