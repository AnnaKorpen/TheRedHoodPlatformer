using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyStateCreator))]
public class EnemySpeedUp : MonoBehaviour
{
    [SerializeField] NPCConfigSO enemyConfig;
    [SerializeField] float speedIncreaser;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float detectorLenght;
    [SerializeField] private float chasingBreakTime;

    private Rigidbody2D enemyRigidbody;
    private EnemyStateCreator enemyState;

    private bool canChasePlayer;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyStateCreator>();

        canChasePlayer = true;
    }

      private void SpeedUp()
    {
        float direction = 1;

        if (enemyState.instance.isFacingRight)
        {
            direction = -1;
        }

        enemyRigidbody.velocity = Vector2.left * enemyConfig.moveSpeed * speedIncreaser * direction;
    }

    private bool DetectPlayer()
    {
        //If player is close, stop speeding up

        Vector2 direction = Vector2.left;

        if (enemyState.instance.isFacingRight)
        {
            direction = Vector2.right;
        }

        bool raycastHitPlayer = Physics2D.Raycast(transform.position, direction, detectorLenght, playerMask);

        return raycastHitPlayer;

    }

    private IEnumerator StartChasingBreakTimer(float timer)
    {
        canChasePlayer = false;

        yield return new WaitForSeconds(timer);

        canChasePlayer = true;
    }

    private void Update()
    {
        if (enemyState.instance.currentActionState == EnemyActionState.PlayerInteracting)
        {

            if (canChasePlayer && enemyState.instance.canWalk)
            {
                SpeedUp();
            }

            bool raycastHitPlayer = DetectPlayer();

            if (raycastHitPlayer && canChasePlayer)
            {
                StartCoroutine(StartChasingBreakTimer(chasingBreakTime));
            }

            if (!enemyState.instance.canWalk && canChasePlayer)
            {
                enemyState.instance.currentActionState = EnemyActionState.Revert;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - detectorLenght, transform.position.y, 0));
    }
}
