using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private MovementBehaviour _movement;
    private ShootBehaviour _shotBehaviour;
    private Vector2 movementInput;

    void Start()
    {
        // Initialize the imported classes
        _sprite = GetComponent<SpriteRenderer>();
        _movement = GetComponent<MovementBehaviour>();
        _shotBehaviour = GetComponent<ShootBehaviour>();
    }

    void Update()
    {
        // Function to enable or disable the godmode
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Godmode toggled");
            GetComponent<HealthBehaviour>().enabled = !GetComponent<HealthBehaviour>().enabled;
        }
    }

    private void FixedUpdate()
    {
        _movement.Move(movementInput);
    }

    void OnFire()
    {
        _shotBehaviour.Shoot();
    }

    void OnMove(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }

    private void OnPause()
    {
        Debug.Log("PauseToggled");
        PauseController.GetInstance().TogglePause();
    }
}
