using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private MovementBehaviour _movement;
    private Vector3 direction;

    void Start()
    {
        _movement = GetComponent<MovementBehaviour>();
    }

    void Update()
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
