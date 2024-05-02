using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
public class EnemyMovementAnimationCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidbody;
    [SerializeField] private EnemyStateCreator enemyState;

    private CharacterAnimation characterAnimation;

    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    private void FixedUpdate()
    {
        CheckMoveAnimation();
    }

    private void CheckMoveAnimation()
    {
        if (Mathf.Abs(enemyRigidbody.velocity.x) > 0.1f)
        {
            characterAnimation.MoveAnimation(true, enemyState.instance.isFacingRight);
        }
        else
        {
            characterAnimation.MoveAnimation(false, enemyState.instance.isFacingRight);
        }
    }

}
