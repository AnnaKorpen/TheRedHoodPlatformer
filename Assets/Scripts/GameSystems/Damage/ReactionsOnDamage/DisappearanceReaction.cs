using System.Collections;
using UnityEngine;

public class DisappearanceReaction : MonoBehaviour
{
    [SerializeField] private float timeDelay;

    public void DestroyWithDelay()
    {
        Destroy(gameObject, timeDelay);
    }    

    public void DisableWithDelay()
    {
        StartCoroutine(StartDisable());
    }

    private IEnumerator StartDisable()
    {
        yield return new WaitForSeconds(timeDelay);
        gameObject.SetActive(false);
    }
}
