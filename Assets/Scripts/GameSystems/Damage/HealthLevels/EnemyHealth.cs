using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public UnityEvent OnEnemyDamaged;
    public UnityEvent OnEnemyDeath;

    [SerializeField] private NPCConfigSO enemyConfig;

    private EnemyStateCreator enemyState;
    private bool isAlive;

    private void Start()
    {
        enemyState = GetComponent<EnemyStateCreator>();

        enemyState.instance.currentHealth = enemyConfig.maxHealth;
        enemyState.instance.isImmuned = false;

        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        if (!enemyState.instance.isImmuned)
        {
            enemyState.instance.currentHealth -= damage;
            OnEnemyDamaged.Invoke();

            CheckIsAlive();
        }
    }

    private void CheckIsAlive()
    {
        if (enemyState.instance.currentHealth <= 0)
        {
            isAlive = false;

            enemyState.instance.currentHealth = 0;

            OnEnemyDeath.Invoke();
        }

    }

    public bool IsAlive()
    {
        return isAlive;
    }

}
