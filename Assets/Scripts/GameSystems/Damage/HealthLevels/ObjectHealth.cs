using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, IDamageable
{
    public UnityEvent OnObjectDamaged;
    public UnityEvent OnObjectDeath;

    [SerializeField] private FloatValueSO objectMaxHealth;

    [HideInInspector]public float currentHealth;

    private void Awake()
    {
        currentHealth = objectMaxHealth.initialValue;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnObjectDamaged.Invoke();

        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
        { 
            currentHealth = 0;

            OnObjectDeath.Invoke();
        }

    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
