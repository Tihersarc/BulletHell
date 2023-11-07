using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthBehaviour h) && h.enabled)
        {
            Debug.Log("hit");
            h.Damage(damage);
        }
    }
}