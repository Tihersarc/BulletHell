using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float currentHealth;

    public UnityEvent OnHealthChange;

    public UnityEvent OnDie;
    
    void Start()
    {
        ResetHealth();
    }

    public void Heal(int quantity)
    {
        currentHealth += quantity;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDie.Invoke();
        }

        OnHealthChange.Invoke();
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        OnHealthChange.Invoke();
    }
}
