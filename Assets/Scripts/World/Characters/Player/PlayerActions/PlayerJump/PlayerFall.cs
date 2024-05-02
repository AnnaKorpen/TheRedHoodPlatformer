using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFall : MonoBehaviour
{
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private PlayerCurrentStateSO playerState;

    public float playerGravity;

    private Rigidbody2D playerRigidbody;

    private bool isFastFalling;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        isFastFalling = false;
    }

    private void FixedUpdate()
    {
        CheckFalling();

        if (playerState.isGrounded)
        {
            isFastFalling = false;
        }

        playerGravity = playerRigidbody.gravityScale;
    }
    private void SetGravityScale(float gravityScale)
    {
        playerRigidbody.gravityScale = gravityScale;

        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Mathf.Max(playerRigidbody.velocity.y, -playerConfig.gravityConfig.maxFallSpeed));
    }

    private void CheckFalling()
    {
        if (playerRigidbody.velocity.y < 0 && !playerState.isDashing && !isFastFalling)
        {
            SetGravityScale(playerConfig.gravityConfig.fallGravityMultiplier);
        }
    }

    public void FastFall()
    {
        if (!playerState.isGrounded)
        {
            isFastFalling = true;

            SetGravityScale(playerConfig.gravityConfig.fastFallGravityMultiplier);
        }
    }
}
