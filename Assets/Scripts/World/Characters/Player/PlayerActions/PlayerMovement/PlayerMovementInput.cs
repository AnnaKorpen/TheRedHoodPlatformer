using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerDash))]
public class PlayerMovementInput : MonoBehaviour
{
    [SerializeField] private PlayerCurrentStateSO playerState;

    private PlayerMovement playerMovement;
    private PlayerDash playerDash;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerDash = GetComponent<PlayerDash>();

        playerState.isControllerOn = true;
    }

    private void Update()
    {
        if (playerState.isControllerOn)
        {
            CheckMovementButtonsPressed();
            CheckDashButtonPressed();
        }
    }

    private void CheckMovementButtonsPressed()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        playerMovement.Move(horizontalDirection);
    }

    private void CheckDashButtonPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerDash.Dash();
        }
    }
}
