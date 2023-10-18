using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerBehaviour : MonoBehaviour
{
    //[SerializeField] private GameObject _playerController;

    // Classes importades
    private Animator _animator;
    private SpriteRenderer _sprite;
    private MovementBehaviour _movement;
    private ShootBehaviour _shotBehaviour;
    private Vector2 _movementInput;
    

    // Variable to know if the player is facing left or right on the X axis

    void Start()
    {
        // Initialize the imported classes
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _movement = GetComponent<MovementBehaviour>();
        _shotBehaviour = GetComponent<ShootBehaviour>();
    }

    void Update()
    {
        if (_movementInput != Vector2.zero)
        {
            _movement.Move(_movementInput);
        }

        // Function to enable or disable the godmode
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Godmode toggled");
            GetComponent<HealthBehaviour>().enabled = !GetComponent<HealthBehaviour>().enabled;
        }
    }

    void OnFire()
    {
        _shotBehaviour.Shoot();
    }

    void OnMove(InputValue input)
    {
        _movementInput = input.Get<Vector2>();
    }

    private void OnPause()
    {
        Debug.Log("PauseToggled");
        PauseController.GetInstance().TogglePause();
    }
}

