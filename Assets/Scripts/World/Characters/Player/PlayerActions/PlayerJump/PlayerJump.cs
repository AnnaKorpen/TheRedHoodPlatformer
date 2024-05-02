using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private PlayerCurrentStateSO playerState;
    [SerializeField] private GameEventSO onPlayerJump;

    private Rigidbody2D playerRigidbody;

    private bool isJumping;
    private float movementSpeedBeforeJump;

    private float jumpTimeToAppex;
    private float jumpForce;
    private float jumpGravityScale;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isJumping && playerRigidbody.velocity.y <= 0)
        {
            isJumping = false;
        }

        AddInitialMovementSpeedInJump();
    }

    private void CalculateJumpSettings()
    {
        float fallGravity = playerConfig.gravityConfig.fallGravityMultiplier * Physics2D.gravity.y;
        float jumpTimeWithFallGravity = Mathf.Sqrt(-(2 * playerConfig.jumpConfig.maxJumpHight) / fallGravity);

        float jumpTimeFromAppex = jumpTimeWithFallGravity / 2;
        jumpTimeToAppex = (playerConfig.jumpConfig.maxJumpDistance / playerConfig.movementConfig.moveAcceleration) - jumpTimeFromAppex;

        float gravity = -(2 * playerConfig.jumpConfig.maxJumpHight) / (jumpTimeToAppex * jumpTimeToAppex);

        jumpGravityScale = gravity / Physics2D.gravity.y;
        jumpForce = Mathf.Abs(gravity) * jumpTimeToAppex;
    }

    private void AddInitialMovementSpeedInJump()
    {
        if (isJumping && Mathf.Abs(playerState.currentDirection) < 0.1f && !playerState.isDashing)
        {
            playerRigidbody.AddForce(movementSpeedBeforeJump * Vector2.right, ForceMode2D.Force);
        }
    }

    private void AddJumpingForce(Vector2 force)
    {
        // Increase force if Player is falling
        if (playerRigidbody.velocity.y < 0)
        {
            force.y -= playerRigidbody.velocity.y;
        }

        playerRigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void VerticalJump()
    {
        isJumping = true;
        movementSpeedBeforeJump = playerRigidbody.velocity.x;
        playerRigidbody.gravityScale = jumpGravityScale;

        Vector2 force = Vector2.up * jumpForce;

        AddJumpingForce(force);
        onPlayerJump?.TriggerEvent();
    }

    public void TryWallJump()
    {
        if ((playerState.onWallRight && !playerState.isFacingRight) || (playerState.onWallLeft && playerState.isFacingRight))
        {
            isJumping = true;
            playerRigidbody.gravityScale = jumpGravityScale;

            Vector2 force = new Vector2(jumpForce / 2, jumpForce);
            force.x *= GetWallJumpDirection();

            AddJumpingForce(force);
            onPlayerJump?.TriggerEvent();
        }
    }

    private float GetWallJumpDirection()
    {
        if (playerState.isFacingRight)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public void JumpPressed(bool jumpButtonPressed)
    {
        if (playerState.canJump && jumpButtonPressed)
        {
            CalculateJumpSettings();

            if (playerState.isGrounded)
            {
                VerticalJump();
            }
            else
            {
                TryWallJump();
            }
        }
    }
}
