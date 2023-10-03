using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private MovementBehaviour _movement;

    void Start()
    {
        _movement = GetComponent<MovementBehaviour>();
    }

    void Update()
    {
        _movement.Move(Vector3.up); //Move towards the direction the gameobject is moving
    }
}
