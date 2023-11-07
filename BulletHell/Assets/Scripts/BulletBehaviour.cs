using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private MovementBehaviour _movement;
    private Vector3 direction;

    void Start()
    {
        _movement = GetComponent<MovementBehaviour>();
    }

    void FixedUpdate()
    {
        _movement.Move(direction);
    }

    public void Init(Vector3 dir)
    {
        direction = dir;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
