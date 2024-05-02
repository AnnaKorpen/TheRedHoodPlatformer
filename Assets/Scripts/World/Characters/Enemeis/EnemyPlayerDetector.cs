using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float detectorLenght;

    private EnemyStateCreator enemyState;

    private bool playerDetected;

    private void Start()
    {
        enemyState = GetComponent<EnemyStateCreator>();
    }

    private void FixedUpdate()
    {
        if (enemyState.instance.currentActionState == EnemyActionState.PlayerDetecting)
        {
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        Vector2 direction = CalculateDirection();
        bool raycastHitPlayer = Physics2D.Raycast(transform.position, direction, detectorLenght, playerMask);

        if (raycastHitPlayer && !playerDetected)
        {
            playerDetected = true;
            enemyState.instance.currentActionState = EnemyActionState.PlayerInteracting;
        }

        if (!raycastHitPlayer && playerDetected)
        {
            playerDetected = false;
            enemyState.instance.currentActionState = EnemyActionState.PlayerDetecting;
        }
    }

    private Vector2 CalculateDirection()
    {
        Vector2 direction = Vector2.left;

        if (enemyState.instance.isFacingRight)
        {
            direction = Vector2.right;
        }

        return direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - detectorLenght, transform.position.y, 0));
    }

}
