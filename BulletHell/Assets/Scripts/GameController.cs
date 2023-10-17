using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static UnityEvent OnLevelFinish;

    public static int enemyCount;

    [SerializeField] private List<GameObject> EnemyList;

    void Start()
    {
        EnemyList = new List<GameObject>();
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        //{
        //    EnemyList.Add(enemy);
        //}
    }

    public static void RemoveEnemy()
    {
        //EnemyList.Remove(enemy);
        enemyCount--;

        if (enemyCount <= 0 ) {
             OnLevelFinish.Invoke();
            Debug.Log("ALL ENEMIES DEFEATED");
        }
    }
}
