using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 direction;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(float s) {
        speed = s;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetDirection(Vector3 dir)
    {
        this.direction = dir;
    }

    public Vector3 GetDirection()
    {
        return this.direction;
    }

    public void SetRotationToDirection()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public void Move(Vector3 dir)
    {
        direction.Normalize();
        rb.velocity = speed * dir;
    }

    public void Move()
    {
        direction.Normalize();
        rb.velocity = speed * direction;
    }

    public void MoveTransform()
    {
        transform.position += speed * Time.deltaTime * direction;
    }
}
