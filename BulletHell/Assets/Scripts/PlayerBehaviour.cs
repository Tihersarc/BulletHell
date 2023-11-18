using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private MovementBehaviour movement;
    private ShootBehaviour shotBehaviour;
    private Animator animator;
    private Vector2 movementInput;

    void Start()
    {
        // Initialize the imported classes
        movement = GetComponent<MovementBehaviour>();
        shotBehaviour = GetComponent<ShootBehaviour>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Function to enable or disable the godmode
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Godmode toggled");
            GetComponent<HealthBehaviour>().enabled = !GetComponent<HealthBehaviour>().enabled;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Shield activated");
            GetComponent<ShieldBehaviour>().EnableShield();
        }
    }

    private void FixedUpdate()
    {
        movement.Move(movementInput);
    }

    

    void OnFire()
    {
        shotBehaviour.Shoot();
    }

    void OnMove(InputValue input)
    {
        movementInput = input.Get<Vector2>();
        float xInput = movementInput.x;

        if (xInput > 0f)
        {
            animator.SetInteger("state", 2);
        }
        else if (xInput < 0f) 
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
    }

    private void OnPause()
    {
        Debug.Log("PauseToggled");
        PauseController.GetInstance().TogglePause();
    }
}
