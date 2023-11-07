using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bulletInstance.GetComponent<BulletBehaviour>().Init(_shootPoint.transform.right);
    }

    public GameObject GetShootPoint()
    {
        return _shootPoint;
    }
}
