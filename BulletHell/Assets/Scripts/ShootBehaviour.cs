using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;

    void Start()
    {
        
    }

    public void Shoot()
    {
        Instantiate(_bullet, _shootPoint.transform.position, this.transform.rotation); // Add rotation towards where is going
    }
}
