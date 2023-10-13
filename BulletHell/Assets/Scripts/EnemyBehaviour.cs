using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    enum Pattern { Straight, Spin}

    [SerializeField] private GameObject shootPoint;

    private ShootBehaviour shootBehaviour;
    private float rotation;
    private float timer;

    enum Spawn { A, B }

    //[Header("Bullet Attributes")]
    //[SerializeField] private GameObject bullet; // -----TODO

    [Header("Bullet Patterns")]
    [SerializeField] private Pattern pattern;
    [SerializeField] private float shootingRate;

    void Start()
    {
        shootBehaviour = GetComponent<ShootBehaviour>();
        timer = 0f;
        rotation = 0f;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (pattern == Pattern.Spin)
        {
            shootPoint.transform.eulerAngles = new Vector3(0, 0, shootPoint.transform.eulerAngles.z + 1f);
        }

        if (timer >= shootingRate)
        {
            shootBehaviour.Shoot();
            timer = 0f;
        }
    }
}
