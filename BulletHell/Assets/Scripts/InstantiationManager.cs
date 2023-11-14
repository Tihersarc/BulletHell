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

    // Poner en corutina-----------------------------------------------
    private void Update()
    {
        totalTime += Time.deltaTime;

        while (enemyInstantiations.Count > 0)
        {
            foreach (EnemyInstantiation e in enemyInstantiations)
            {
                if (e.timeToInstantiate >= totalTime)
                {
                    Instantiate(e.enemyToInstantiate);
                    //enemyInstantiations.Remove(e);
                }
            }
        }
    }

}
