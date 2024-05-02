using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] float disappearingDuration;
    [SerializeField] float disappearingDelay;
    [SerializeField] float changingStateTime;
    [SerializeField] bool startAfterHit;

    public UnityEvent OnChangeState;

    private bool isFirstHit;

    private void OnEnable()
    {
        if (!startAfterHit)
        {
            StartCoroutine(StartDisappearingCycle());
        }
    }

    private void Awake()
    {
        isFirstHit = true;
    }

    private void ChangeState(bool isActive)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }

    private IEnumerator StartDisappearingCycle()
    {
        while(true)
        {
            ChangeState(false);

            //Timer to start change state
            yield return new WaitForSeconds(disappearingDuration);
            ChangeState(true);

            //Appearing Timer
            OnChangeState.Invoke();
            yield return new WaitForSeconds(changingStateTime);

            //Timer to return to the previous state
            yield return new WaitForSeconds(disappearingDelay);

            //Warning Timer
            OnChangeState.Invoke();
            yield return new WaitForSeconds(changingStateTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit the Platform");

        if (startAfterHit && isFirstHit)
        {
            StartCoroutine(StartDisappearingCycle());

            isFirstHit = false;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
