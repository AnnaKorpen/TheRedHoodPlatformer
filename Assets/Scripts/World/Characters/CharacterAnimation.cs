using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator characterAnimator;
    private SpriteRenderer characterRenderer;

    private void Awake()
    {
        characterAnimator = GetComponent<Animator>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    public void DeathAnimation()
    {
        characterAnimator.SetTrigger(GlobalStringVars.IS_DEAD);
    }

    public void HurtAnimatiom()
    {
        characterAnimator.SetTrigger(GlobalStringVars.IS_HURT);
    }

    public void JumpAnimation()
    {
        characterAnimator.SetTrigger(GlobalStringVars.IS_JUMPING);
    }

    public void FallAnimation(bool isFalling)
    {
        characterAnimator.SetBool(GlobalStringVars.IS_FALLING, isFalling);
    }

    public void MoveAnimation(bool isMoving, bool isFacingRight)
    {
        characterAnimator.SetBool(GlobalStringVars.IS_MOVING, isMoving);
        characterRenderer.flipX = !isFacingRight;
    }

    public void AttackAnimation()
    {
        characterAnimator.SetTrigger(GlobalStringVars.IS_ATTACKING);
    }

    public void ShootAnimation()
    {
        characterAnimator.SetTrigger(GlobalStringVars.IS_SHOOTING);
    }

    public void DashAnimation()
    {
        characterAnimator.SetTrigger(GlobalStringVars.IS_DASHING);
    }
}
