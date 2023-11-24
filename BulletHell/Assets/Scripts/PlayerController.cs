using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI healthText;

    public static PlayerInput PlayerInputInstance {  get; private set; }

    private void Start()
    {
        PlayerInputInstance = player.GetComponent<PlayerInput>();
    }

    public void UpdateCanvas()
    {
        float hp = player.GetComponent<HealthBehaviour>().GetCurrentHealth();
        healthText.text = "HP: " + hp;
    }

    public static void EnablePlayerInput()
    {
        PlayerInputInstance.enabled = true;
    }

    public static void DisablePlayerInput()
    {
        PlayerInputInstance.enabled = false;
    }
}
