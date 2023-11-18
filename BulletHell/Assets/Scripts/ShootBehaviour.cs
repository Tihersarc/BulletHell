using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bulletInstance.GetComponent<MovementBehaviour>().SetDirection(_shootPoint.transform.right);
    }

    public void ShootPlayer()
    {
        Vector3 playerDirection = player.transform.position - _shootPoint.transform.position;


        GameObject bulletInstance = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bulletInstance.GetComponent<MovementBehaviour>().SetDirection(playerDirection);

    }

    public GameObject GetShootPoint()
    {
        return _shootPoint;
    }
}
