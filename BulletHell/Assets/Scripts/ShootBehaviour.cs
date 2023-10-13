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
        //GameObject bulletIntance = Instantiate(_bullet, _shootPoint.transform.position, this.transform.rotation); // Add rotation towards where is going
        GameObject bulletInstance = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bulletInstance.GetComponent<BulletBehaviour>().Init(_shootPoint.transform.right);
    }
}
