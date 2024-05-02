using UnityEngine;

public class PlayerFantasyLevel : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatValueSO currentFantasyLevel;
    [SerializeField] private PlayerCurrentStateSO currentState;

    [SerializeField] private GameEventSO onDamaged;
    [SerializeField] private GameEventSO onDeath;

    private bool isAlive;

    private void Awake()
    {
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        if (!currentState.isImmuned)
        {
            currentFantasyLevel.runtimeValue -= damage;
            onDamaged.TriggerEvent();
            CheckIsAlive();
            Debug.Log(currentFantasyLevel.runtimeValue);
        }
    }

    private void CheckIsAlive()
    {
        if (currentFantasyLevel.runtimeValue <= 0)
        {
            onDeath.TriggerEvent();
            isAlive = false;
        }

    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
