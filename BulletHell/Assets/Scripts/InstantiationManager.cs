using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyInstantiation
    {
        public GameObject enemyToInstantiate;
        [Range(-8f, 8f)]
        public float positionX; // Add X range -8 to 8
        public float positionY;
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
                        Vector2 positionToInstantiate = new(e.positionX, e.positionY);
                        GameObject g = Instantiate(e.enemyToInstantiate, positionToInstantiate, Quaternion.identity);
                        g.GetComponent<MovementBehaviour>().SetDirection(Vector3.down);

                        if (g.TryGetComponent(out EnemyBehaviour ebhv))
                        {
                            g.GetComponent<MovementBehaviour>().SetRotationToDirection();
                        }

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
