using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController realWorldAnimator;
    [SerializeField] private RuntimeAnimatorController fantasyWorldAnimator;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeToRealWorldAnimator()
    {
        animator.runtimeAnimatorController = realWorldAnimator;
    }

    public void ChangeToFantasyWorldAnimator()
    {
        animator.runtimeAnimatorController = fantasyWorldAnimator;
    }
}
