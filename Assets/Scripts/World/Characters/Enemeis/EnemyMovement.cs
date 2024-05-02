using UnityEngine;

[RequireComponent(typeof(EnemyStateCreator))]
[RequireComponent (typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NPCConfigSO enemyConfig;

    private EnemyStateCreator enemyState;
    private Rigidbody2D enemyRigidbody;

    private float currentSpeed;
    private float revertingTimer;
    private float pauseTimer;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyStateCreator>();

        enemyState.instance.isFacingRight = false;
        enemyState.instance.currentActionState = EnemyActionState.Idle;
        currentSpeed = enemyConfig.moveSpeed;
    }

    private void Update()
    {
        switch(enemyState.instance.currentActionState)
        {
            case EnemyActionState.Idle:
                TryWalking();
                break;
            case EnemyActionState.PlayerDetecting:
                Walking();
                break;
            case EnemyActionState.Revert:
                RevertEnemy();
                break;
            case EnemyActionState.PlayerInteracting:
                break;
            case EnemyActionState.Pause:
                StayPause();
                break;
        }
    }

    private void RevertEnemy()
    {
        revertingTimer -= Time.deltaTime;

        if (revertingTimer <= 0)
        {
            currentSpeed *= -1;
            revertingTimer = Random.Range(enemyConfig.minDesicionTime, enemyConfig.maxDesicionTime);

            enemyState.instance.isFacingRight = !enemyState.instance.isFacingRight;

            enemyState.instance.currentActionState = EnemyActionState.Idle;
        }
    }

    private void TryWalking()
    {
        if (enemyState.instance.canWalk)
        {
            enemyState.instance.currentActionState = EnemyActionState.PlayerDetecting;
        }
    }

    private void Walking()
    {
        enemyRigidbody.velocity = Vector2.left * currentSpeed;

        if (!enemyState.instance.canWalk)
        {
            enemyState.instance.currentActionState = EnemyActionState.Revert;
        }
    }

    private void StayPause()
    {
        pauseTimer += Time.deltaTime;

        if (pauseTimer >= enemyConfig.minDesicionTime)
        {
            pauseTimer = 0;
            enemyState.instance.currentActionState = EnemyActionState.PlayerDetecting;
        }
    }

    public void Pause()
    {
        enemyState.instance.currentActionState = EnemyActionState.Pause;
    }
}
