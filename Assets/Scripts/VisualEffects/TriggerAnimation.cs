using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private string triggerName;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger()
    {
        animator.SetTrigger(triggerName);
    }
}
