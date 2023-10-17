using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    enum Pattern { Straight, Spin }

    [SerializeField] private GameObject shootPoint;

    private GameController gameController;

    private ShootBehaviour shootBehaviour;
    //private float rotation;
    private float timer;

    enum Spawn { A, B }

    [Header("Bullet Patterns")]
    [SerializeField] private Pattern pattern;
    [SerializeField] private float shootingRate;
    [SerializeField] private float rotationRate;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        shootBehaviour = GetComponent<ShootBehaviour>();
        timer = 0f;
        //rotation = 0f;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (pattern == Pattern.Spin)
        {
            shootPoint.transform.eulerAngles = new Vector3(0f, 0f, shootPoint.transform.eulerAngles.z + rotationRate);
        }

        if (timer >= shootingRate)
        {
            shootBehaviour.Shoot();
            timer = 0f;
        }
    }

    public void Remove()
    {
        gameController.RemoveEnemy();
    }

}
