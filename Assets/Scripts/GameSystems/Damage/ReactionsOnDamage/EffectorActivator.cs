using System.Collections;
using UnityEngine;

public class EffectorActivator : MonoBehaviour
{
    [SerializeField] private GameObject effector;
    [SerializeField] private float duration;

    private void Awake()
    {
        effector.SetActive(false);
    }

    public void ActivateEffector()
    {
        effector.SetActive(true);

        if (duration > 0 )
        {
            StartCoroutine(StartAtiveEffect());
        }
    }

    private IEnumerator StartAtiveEffect()
    {
        yield return new WaitForSeconds(duration);
        effector.SetActive(false);
    }

    public void DisactivateEffector()
    {
        effector.SetActive(false);
    }
}
