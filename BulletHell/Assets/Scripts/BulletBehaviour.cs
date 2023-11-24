using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private MovementBehaviour movement;

    void Start()
    {
        movement = GetComponent<MovementBehaviour>();
        movement.SetRotationToDirection(90f);
    }

    void FixedUpdate()
    {
        movement.Move();
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
