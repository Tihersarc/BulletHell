using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyInstantiation
    {
        public GameObject enemyToInstantiate;
        public Vector2 positionToInstantiate;
        public float timeToInstantiate;
    }

    [SerializeField] List<EnemyInstantiation> enemyInstantiations;

    float totalTime;

    private void Update()
    {
        totalTime += Time.deltaTime;
    }

}
