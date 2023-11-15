using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyInstantiation
    {
        public GameObject enemyToInstantiate;
        public Vector2 positionToInstantiate; // Add X range -8 to 8
        public float timeToInstantiate;
    }

    [SerializeField] List<EnemyInstantiation> enemyInstantiations;

    private float totalTime;

    private void Start()
    {
        totalTime = 0f;
        StartCoroutine(EnemySpawning());
    }

    IEnumerator EnemySpawning()
    {
        while (enemyInstantiations.Count > 0)
        {
            totalTime += Time.deltaTime;
            for (int i = enemyInstantiations.Count - 1; i >= 0; i--)
            {
                EnemyInstantiation e = enemyInstantiations[i];
                if (e.timeToInstantiate <= totalTime)
                {
                    if (e.enemyToInstantiate != null)
                    {
                        Instantiate(e.enemyToInstantiate, e.positionToInstantiate, Quaternion.identity);
                        enemyInstantiations.Remove(e);
                    }
                    else
                    {
                        Debug.LogError("Trying to instantiate a null object.");
                    }
                }
            }
            yield return null;
        }
    }
}
