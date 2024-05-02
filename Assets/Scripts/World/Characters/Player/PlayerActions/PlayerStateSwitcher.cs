using UnityEngine;

public class PlayerStateSwitcher : MonoBehaviour
{
    [Header("Player Configs")]
    [SerializeField] PlayerConfigSO playerConfig;
    [SerializeField] PlayerMovementConfigSO realWorldMovementConfig;
    [SerializeField] PlayerMovementConfigSO fantasyWorldMovementConfig;

    [Header("Current State")]
    [SerializeField] PlayerCurrentStateSO playerState;

    public void ChangeToRealWorldConfig()
    {
        playerState.canMove = true;
        playerState.canJump = false;
        playerState.canDash = false;
        playerState.canAttack = false;

        playerConfig.movementConfig = realWorldMovementConfig;
    }

    public void ChangeToFantasyWorldConfig()
    {
        playerState.canMove = true;
        playerState.canJump = true;
        playerState.canDash = true;
        playerState.canAttack = true;

        playerConfig.movementConfig = fantasyWorldMovementConfig;
    }

    public void ChangeToLimitedFantasyWorldAbilities()
    {
        playerState.canMove = true;
        playerState.canJump = true;
        playerState.canDash = false;
        playerState.canAttack = false;

        playerConfig.movementConfig = fantasyWorldMovementConfig;
    }
}
