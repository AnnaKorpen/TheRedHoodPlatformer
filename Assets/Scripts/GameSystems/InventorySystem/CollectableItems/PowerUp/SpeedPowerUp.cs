using System.Collections;
using UnityEngine;

public class SpeedPowerUp : BasePowerUpItem
{
    [Header("SpeedData")]
    [SerializeField] private FloatValueSO speedPowerUpTime;
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private PlayerMovementConfigSO powerUpMovementConfig;
  

    public override IEnumerator StartPowerUp()
    {
        PlayerMovementConfigSO previousMovementConfig = playerConfig.movementConfig;

        playerConfig.movementConfig = powerUpMovementConfig;
        onPowerUpStart?.TriggerEvent();

        yield return new WaitForSeconds(speedPowerUpTime.initialValue);

        playerConfig.movementConfig = previousMovementConfig;
        onPowerUpEnd?.TriggerEvent();

        gameObject.SetActive(false);
    }
}
