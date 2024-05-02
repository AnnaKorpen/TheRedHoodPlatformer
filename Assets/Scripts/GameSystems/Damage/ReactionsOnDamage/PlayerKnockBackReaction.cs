using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerKnockBackReaction : MonoBehaviour
{
    [SerializeField] private PlayerCurrentStateSO playerState;
    [SerializeField] private PlayerConfigSO playerConfig;

    private Rigidbody2D playerRigidbody;
    private bool isKnockingBack;
    private float timer;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void StartReaction()
    {
        isKnockingBack = true;
    }

    public void KnockBack()
    {
        playerRigidbody.gravityScale = playerConfig.gravityConfig.normalGravityScale;

        Vector2 forceDirection = CalculateForceDirection();

        if(playerState.isGrounded)
        {
            playerRigidbody.velocity = new Vector2 (playerConfig.reactionConfig.knockbackForceOnGround.x * forceDirection.x, playerConfig.reactionConfig.knockbackForceOnGround.y * forceDirection.y);
        }
        else
        {
            playerRigidbody.velocity = new Vector2(playerConfig.reactionConfig.knockbackForceInAir.x * forceDirection.x, playerConfig.reactionConfig.knockbackForceInAir.y * forceDirection.y);
        }
        
    }

    private Vector2 CalculateForceDirection()
    {
        Vector2 forceDirection = new Vector2(-1, 1);

        //If enemy is on the left side of the player
        if (playerState.currentDamageDealer.x < transform.position.x)
        {
            forceDirection.x = 1;
        }

        //If enemy is under the player
        if (playerState.currentDamageDealer.y > transform.position.y)
        {
            forceDirection.y = -1;
        }

        return forceDirection;
    }

    private void Update()
    {
        if (isKnockingBack)
        {
            timer += Time.deltaTime;

            KnockBack();
            playerState.isControllerOn = false;
            
            if (timer > playerConfig.reactionConfig.knockTime)
            {
                isKnockingBack = false;
                playerState.isControllerOn = true;
                timer = 0;
            }
        }
    }
}
