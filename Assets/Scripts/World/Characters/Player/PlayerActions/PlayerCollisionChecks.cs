using UnityEngine;

public class PlayerCollisionChecks : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private PlayerCurrentStateSO playerState;
    [SerializeField] private PlayerConfigSO playerConfig;

    [Header("Collision Checks")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private Transform rightWallColliderTransform;
    [SerializeField] private Transform leftWallColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask wallMask;

    private void Awake()
    {
        playerState.isGrounded = true;
    }

    private void FixedUpdate()
    {
        CheckIsNearGround();
        CheckIsGrounded();
        CheckWalls();
    }

    private void CheckIsGrounded()
    {
        Vector2 overlapGroundPosition = groundColliderTransform.position;
        playerState.isGrounded = Physics2D.OverlapBox(overlapGroundPosition, playerConfig.collisionConfig.groundCollisionCheckSize, 0, groundMask);
    }

    private void CheckIsNearGround()
    {
        Vector2 overlapCirclePosition = groundColliderTransform.position;
        playerState.isNearGround = Physics2D.OverlapBox(overlapCirclePosition, playerConfig.collisionConfig.nearGroundCollisionCheckSize, 0, groundMask);
    }

    private void CheckWalls()
    {
        Vector2 rightWallPosition = rightWallColliderTransform.position;
        Vector2 leftWallPosition = leftWallColliderTransform.position;

        playerState.onWallRight = Physics2D.OverlapBox(rightWallPosition, playerConfig.collisionConfig.wallCollisionCheckSize, 0, wallMask);
        playerState.onWallLeft = Physics2D.OverlapBox(leftWallPosition, playerConfig.collisionConfig.wallCollisionCheckSize, 0, wallMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundColliderTransform.position, playerConfig.collisionConfig.groundCollisionCheckSize);
        Gizmos.DrawWireCube(groundColliderTransform.position, playerConfig.collisionConfig.nearGroundCollisionCheckSize);
        Gizmos.DrawWireCube(rightWallColliderTransform.position, playerConfig.collisionConfig.wallCollisionCheckSize);
        Gizmos.DrawWireCube(leftWallColliderTransform.position, playerConfig.collisionConfig.wallCollisionCheckSize);
    }
}
