using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float _currentHealth;
    [SerializeField]private float _startHealth;
    public float Currenthealth { get { return _currentHealth; } }

    private void Awake()
    {
        _currentHealth = _startHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Debug.Log(gameObject + "Took damage");
            Death();
        }
    }
    protected virtual void Death()
    {
        Debug.Log("Enemy Died.");
    }
    protected virtual void HandleDamage()
    {

    }
}
