using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnLevelFinish;
    public UnityEvent OnLevelFail;

    private int enemyCount;

    void Start()
    {
        //enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Time.timeScale = 1.0f;
    }

    //public void RemoveEnemy()
    //{
    //    enemyCount--;

    //    if (enemyCount <= 0 ) {
    //         LevelFinished();
    //    }
    //}

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
