using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI healthText;

    public static PlayerInput playerInput;

    public static GameObject PlayerInstance { get; private set; }

    private void Awake()
    {
        PlayerInstance = player;
    }

    private void Start()
    {
        playerInput = PlayerInstance.GetComponent<PlayerInput>();
    }

    public void UpdateCanvas()
    {
        float hp = player.GetComponent<HealthBehaviour>().GetCurrentHealth();
        healthText.text = "HP: " + hp;
    }

    public static void EnablePlayerInput()
    {
        playerInput.enabled = true;
    }

    public static void DisablePlayerInput()
    {
        playerInput.enabled = false;
    }
}
