using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private MovementBehaviour _movement;

    void Start()
    {
        _movement = GetComponent<MovementBehaviour>();
    }

    void FixedUpdate()
    {
        _movement.Move();
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
