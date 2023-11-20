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

    public void SetRotationToDirection(float offset)
    {
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(direction.x, direction.y, direction.z));
        Quaternion finalRotation = Quaternion.Euler(0,0, offset) * targetRotation;
        transform.rotation = finalRotation;
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
        direction.Normalize();
        transform.position += speed * Time.deltaTime * direction;
    }
}
