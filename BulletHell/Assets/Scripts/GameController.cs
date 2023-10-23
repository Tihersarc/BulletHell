using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnLevelFinish;

    private int enemyCount;

    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void RemoveEnemy()
    {
        enemyCount--;

        if (enemyCount <= 0 ) {
             OnLevelFinish.Invoke();
            Debug.Log("ALL ENEMIES DEFEATED");
        }
    }
}
