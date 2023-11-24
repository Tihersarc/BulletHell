using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;

    private GameObject player;
    private Vector3 playerDirection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDirection = Vector3.down;
    }

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bulletInstance.GetComponent<MovementBehaviour>().SetDirection(_shootPoint.transform.right);
        ShootSound();
    }

    public void ShootPlayer()
    {
        if (player != null)
        {
            playerDirection = player.transform.position - _shootPoint.transform.position;
        }

        GameObject bulletInstance = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bulletInstance.GetComponent<MovementBehaviour>().SetDirection(playerDirection);
        ShootSound();
    }

    public GameObject GetShootPoint()
    {
        return _shootPoint;
    }

    public void ShootSound()
    {
        AudioManager.Play("Shot");
    }
}
