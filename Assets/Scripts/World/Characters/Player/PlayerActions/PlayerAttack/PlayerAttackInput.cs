using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private PlayerCurrentStateSO playerState;
    [SerializeField] private MeleeWeapon weapon;

    private void Update()
    {
        if(playerState.isControllerOn && playerState.canAttack)
        {
            CheckAttackButtonPressed();
        }
    }

    private void CheckAttackButtonPressed()
    {
        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            weapon.Attack(playerState.isFacingRight);
        }
    }
}
