using System.Collections;
using UnityEngine;

public class AttackDamagePowerUp : BasePowerUpItem
{
    [Header("AttackDamageData")]
    [SerializeField] private FloatValueSO attackDamagePowerUpTime;
    [SerializeField] private FloatValueSO playerAttackDamage;
    [SerializeField] private FloatValueSO powerUpDamageIncreaser;

    public override IEnumerator StartPowerUp()
    {
        playerAttackDamage.runtimeValue = playerAttackDamage.initialValue * powerUpDamageIncreaser.initialValue;
        onPowerUpStart?.TriggerEvent();

        yield return new WaitForSeconds(attackDamagePowerUpTime.initialValue);

        playerAttackDamage.runtimeValue = playerAttackDamage.initialValue;
        onPowerUpEnd?.TriggerEvent();

        gameObject.SetActive(false);
    }
}
