using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private Transform rightGroundColliderTransform;
    [SerializeField] private Transform leftGroundColliderTransform;
    [SerializeField] private Transform rightWallColliderTransform;
    [SerializeField] private Transform leftWallColliderTransform;

    [Header("Collision Settings")]
    [SerializeField] private float groundCollisionDistance;
    [SerializeField] private Vector2 wallCollisionCheckSize;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask wallMask;

    private bool isGroundedOnLeft;
    private bool isGroundedOnRight;
    private bool hitWallRight;
    private bool hitWallLeft;

    private EnemyStateCreator enemyState;

    private void Start()
    {
        enemyState = GetComponent<EnemyStateCreator>();
    }

    private void FixedUpdate()
    {
        CheckIsGrounded();
        CheckWalls();

        bool canWalkRight = enemyState.instance.isFacingRight && !hitWallRight && isGroundedOnRight;
        bool canWalkLeft = !enemyState.instance.isFacingRight && !hitWallLeft && isGroundedOnLeft;
        enemyState.instance.canWalk = canWalkRight || canWalkLeft;
    }

    private void CheckIsGrounded()
    {
        Vector2 overlapLeftGroundPosition = leftGroundColliderTransform.position;
        isGroundedOnLeft = Physics2D.Raycast(overlapLeftGroundPosition, -Vector2.up, groundCollisionDistance, groundMask);


        Vector2 overlapRightGroundPosition = rightGroundColliderTransform.position;
        isGroundedOnRight = Physics2D.Raycast(overlapRightGroundPosition, -Vector2.up, groundCollisionDistance, groundMask);
    }

    private void CheckWalls()
    {
        Vector2 rightWallPosition = rightWallColliderTransform.position;
        Vector2 leftWallPosition = leftWallColliderTransform.position;

        hitWallRight = Physics2D.OverlapBox(rightWallPosition, wallCollisionCheckSize, 0, wallMask);
        hitWallLeft = Physics2D.OverlapBox(leftWallPosition, wallCollisionCheckSize, 0, wallMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(rightGroundColliderTransform.position.x, rightGroundColliderTransform.position.y, 0), new Vector3(rightGroundColliderTransform.position.x, rightGroundColliderTransform.position.y - groundCollisionDistance, 0));
        Gizmos.DrawLine(new Vector3(leftGroundColliderTransform.position.x, leftGroundColliderTransform.position.y, 0), new Vector3(leftGroundColliderTransform.position.x, leftGroundColliderTransform.position.y - groundCollisionDistance, 0));
        Gizmos.DrawWireCube(rightWallColliderTransform.position, wallCollisionCheckSize);
        Gizmos.DrawWireCube(leftWallColliderTransform.position, wallCollisionCheckSize);
    }
}
