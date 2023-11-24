using System.Collections;
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
        StartCoroutine(WaitLevelFinished());
    }

    public void LevelFailed()
    {
        StartCoroutine(WaitLevelFailed());
    }

    IEnumerator WaitLevelFinished()
    {
        yield return new WaitForSeconds(2f);
        OnLevelFinish.Invoke();
        Debug.Log("Level Finished");
    }

    IEnumerator WaitLevelFailed()
    {
        yield return new WaitForSeconds(2f);
        OnLevelFail.Invoke();
        Debug.Log("Level Failed");
    }
}
