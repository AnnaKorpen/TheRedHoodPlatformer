using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ProducerAnimation : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    public void DeathAnimation()
    {
        animator.SetTrigger(GlobalStringVars.IS_DEAD);
    }

    public void DamageAnimation()
    {
        animator.SetTrigger(GlobalStringVars.IS_HURT);
    }
}
