using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateCanvas()
    {
        float hp = player.GetComponent<HealthBehaviour>().GetCurrentHealth();
        healthText.text = "HP: " + hp;
    }
}
