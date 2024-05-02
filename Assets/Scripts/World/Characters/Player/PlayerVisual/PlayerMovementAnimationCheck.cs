using UnityEngine;

[RequireComponent (typeof(CharacterAnimation))]
public class PlayerMovementAnimationCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private PlayerCurrentStateSO playerState;

    private CharacterAnimation characterAnimation;

    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation> ();
    }

    private void FixedUpdate()
    {
        CheckFallAnimation();
        CheckMoveAnimation();
    }

    private void CheckFallAnimation()
    {
        if (playerRigidbody.velocity.y < 0 && !playerState.isDashing)
        {
            characterAnimation.FallAnimation(true);
        }

        if (playerState.isNearGround || playerState.isDashing)
        {
            characterAnimation.FallAnimation(false);
        }
    }

    private void CheckMoveAnimation()
    {
        if (playerState.isGrounded && Mathf.Abs(playerState.currentDirection) > 0.1f)
        {
            characterAnimation.MoveAnimation(true, playerState.isFacingRight);
        }
        else
        {
            characterAnimation.MoveAnimation(false, playerState.isFacingRight);
        }
    }

}
