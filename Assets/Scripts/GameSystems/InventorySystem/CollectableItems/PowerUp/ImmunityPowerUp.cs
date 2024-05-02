using System.Collections;
using UnityEngine;

public class ImmunityPowerUp : BasePowerUpItem
{
    [Header("ImmunityData")]
    [SerializeField] private FloatValueSO immunityPowerUpTime;
    [SerializeField] private PlayerCurrentStateSO currentState;

      public override IEnumerator StartPowerUp()
    {
        currentState.isImmuned = true;
        onPowerUpStart?.TriggerEvent();

        yield return new WaitForSeconds(immunityPowerUpTime.initialValue);

        currentState.isImmuned = false;
        onPowerUpEnd?.TriggerEvent();

        gameObject.SetActive(false);
    }
}
