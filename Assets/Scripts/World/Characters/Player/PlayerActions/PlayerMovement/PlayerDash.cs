using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private PlayerConfigSO playerConfig;
    [SerializeField] private PlayerCurrentStateSO playerState;
    [SerializeField] private GameEventSO onPlayerDash;

    private Rigidbody2D playerRigidbody;

    private float dashTime;
    private bool dashRefilling;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private float CheckDashDirection(bool isFacingRight)
    {
        if (isFacingRight)
        {
            return 1;
        }
        else
        {
            return -1;
        }

    }

    private IEnumerator StartDash(float dashDirection)
    {
        dashTime = playerConfig.dashConfig.dashDistance / playerConfig.dashConfig.dashSpeed;

        float startTime = Time.time;

        // Apply dashSpeed during dashTime
        while (Time.time - startTime <= dashTime)
        {
            playerRigidbody.velocity = Vector2.right * playerConfig.dashConfig.dashSpeed * dashDirection;
            yield return null;
        }

        //Return Player's controll
        playerState.isControllerOn = true;
        playerRigidbody.gravityScale = playerConfig.gravityConfig.dashEndGravityMultiplier;

        StartCoroutine(EndDash(dashDirection));
    }

    private IEnumerator EndDash(float dashDirection)
    {
        float deccalarationLerp = 0;

        float startTime = Time.time;

        //Smoothly deccalarate Player's speed
        while (Time.time - startTime <= playerConfig.dashConfig.dashEndTime)
        {
            deccalarationLerp += 0.01f;
            float deccalarationSpeed = Mathf.Lerp(playerConfig.dashConfig.dashSpeed, playerConfig.dashConfig.dashEndSpeed, deccalarationLerp);

            playerRigidbody.velocity = Vector2.right * deccalarationSpeed * dashDirection;
            yield return null;
        }

        //Return Player's normal state
        playerRigidbody.gravityScale = playerConfig.gravityConfig.normalGravityScale;
        playerRigidbody.velocity = Vector2.zero;
        playerState.isDashing = false;

        StartCoroutine(RefillDash());
    }

    private IEnumerator RefillDash()
    {
        yield return new WaitForSeconds(playerConfig.dashConfig.dashRefillTime);
        dashRefilling = false;
    }

    public void Dash()
    {
        if (playerState.canDash && !dashRefilling)
        {
            //Set dash state to the Player
            playerState.isDashing = true;
            dashRefilling = true;
            playerRigidbody.gravityScale = 0f;
            playerState.isControllerOn = false;

            //onPlayerDash?.TriggerEvent();

            float dashDirection = CheckDashDirection(playerState.isFacingRight);

            StartCoroutine(StartDash(dashDirection));
        }
    }
}

