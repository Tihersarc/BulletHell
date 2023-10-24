using System.Collections;
using System.Collections.Generic;
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

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Move(Vector3 direction)
    {
        direction.Normalize();
        rb.velocity = speed * direction;
        //transform.position += speed * Time.deltaTime * direction;
    }

    public void Move()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    //public void MoveToPosition()
    //{
    //    transform.position += Vector3.MoveTowards(speed * Time.deltaTime *);
    //}
}
