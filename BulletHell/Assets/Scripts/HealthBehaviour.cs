using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;

    [SerializeField]
    private float _currentHealth;

    public UnityEvent OnHealthChange;

    public UnityEvent OnDie;
    
    void Start()
    {
        ResetHealth();
    }

    public void Heal(int quantity)
    {
        _currentHealth += quantity;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void Damage(int damage)
    {
        _currentHealth -= damage;


        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDie.Invoke(); // Llamar al evento
        }

        OnHealthChange.Invoke();
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        OnHealthChange.Invoke();
    }
}
