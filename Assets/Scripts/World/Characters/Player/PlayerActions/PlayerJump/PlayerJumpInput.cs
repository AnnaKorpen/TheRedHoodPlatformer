using UnityEngine;

[RequireComponent (typeof(PlayerJump))]
[RequireComponent(typeof(PlayerFall))]
public class PlayerJumpInput : MonoBehaviour
{
    [SerializeField] private PlayerCurrentStateSO playerState;

    private PlayerJump playerJump;
    private PlayerFall playerFall;

    private void Awake()
    {
        playerJump = GetComponent<PlayerJump>();
        playerFall = GetComponent<PlayerFall>();
    }

    private void Update()
    {
        if (playerState.isControllerOn)
        {
            CheckJumpButtonPressed();
            CheckFastFallButtonPressed();
        }
    }
    private void CheckJumpButtonPressed()
    {
        bool jumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerJump.JumpPressed(jumpButtonPressed);
    }

    private void CheckFastFallButtonPressed()
    {
        float verticalDirection = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

        if (verticalDirection < 0)
        {
            playerFall.FastFall();
        }
    }
}
