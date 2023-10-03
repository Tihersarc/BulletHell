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

    //[SerializeField]
    //private Image bar;

    //[SerializeField]
    //private TextMeshProUGUI livesText;

    public UnityEvent<int> OnHurt;

    public UnityEvent OnDie;
    
    void Start()
    {
        ResetHealth();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Damage(1);
        }
        //if (livesText != null)
        //{
        //    livesText.SetText("Lives: " + _currentHealth);
        //}
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

        //UpdateHealthBar();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDie.Invoke(); // Llamar al evento
        }
    }

    //public void UpdateHealthBar()
    //{
    //    if (bar != null)
    //    {
    //        bar.fillAmount = _currentHealth / _maxHealth;
    //    }
    //}

    public float Get_currentHealth()
    {
        return _currentHealth;
    }

    public float Get_maxHealth()
    {
        return _maxHealth;
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
}
