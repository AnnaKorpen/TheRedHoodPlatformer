using System;
using System.Collections;
using UnityEngine;

public class TemporaryTimer : MonoBehaviour
{

    public void StartCountTime(float duration, Action action)
    {
        StartCoroutine(CountTime(duration, action));
    }


    private IEnumerator CountTime(float duration, Action action)
    {
        yield return new WaitForSeconds(duration);
        action();
        Destroy(this);
    }
}
