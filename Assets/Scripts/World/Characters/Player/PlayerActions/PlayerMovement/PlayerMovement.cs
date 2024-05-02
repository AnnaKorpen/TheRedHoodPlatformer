using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private PlayerCurrentStateSO playerState;

    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Turn(float direction)
    {
        if (direction > 0)
        {
            playerState.isFacingRight = true;
        }
        else if (direction < 0)
        {
            playerState.isFacingRight = false;
        }
    }

    private void HorizontalMovement()
    {
        float targetSpeed = playerState.currentDirection * playerConfig.movementConfig.maxMovementSpeed;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? playerConfig.movementConfig.moveAcceleration : playerConfig.movementConfig.moveDecceleration;

        float speedDif = targetSpeed - playerRigidbody.velocity.x;
        float movement = speedDif * accelRate;

        playerRigidbody.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    private float StopMovementOnWall(float direction)
    {
        if (!playerState.isGrounded && playerState.onWallRight && direction > 0.1f)
        {
            return 0;
        }

        if(!playerState.isGrounded && playerState.onWallLeft && direction < -0.1f)

        {
            return 0;
        }

        return direction;
    }

    public void Move(float direction)
    {
        if (playerState.canMove)
        {
            direction = StopMovementOnWall(direction);

            // Diretion can be zero and it should stop the Player only on the ground
            if (Mathf.Abs(direction) > 0.1f || playerState.isGrounded)
            {
                playerState.currentDirection = direction;
                HorizontalMovement();
                Turn(direction);
            }
        }
    }
}
