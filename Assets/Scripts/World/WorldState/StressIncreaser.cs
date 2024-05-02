using System.Collections;
using UnityEngine;

public class StressIncreaser : MonoBehaviour
{
    [SerializeField] private FloatValueSO stressLevel;
    [SerializeField] private WorldStateSO worldState;
    [SerializeField] private FloatValueSO constantStressLevelIncreaser;

    private IEnumerator currentRoutine;

    private void Awake()
    {
        currentRoutine = IncreaseStressLevel();
    }

    private IEnumerator IncreaseStressLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            stressLevel.runtimeValue += constantStressLevelIncreaser.runtimeValue;
        }
    }

    public void StartStressLevelIncreaser()
    {
        StartCoroutine(currentRoutine);
    }

    public void StopStresslevelIncreaser()
    {
        StopCoroutine(currentRoutine);
    }

    public void ResetStressLevel()
    {
        stressLevel.runtimeValue = stressLevel.initialValue;
    }
}
