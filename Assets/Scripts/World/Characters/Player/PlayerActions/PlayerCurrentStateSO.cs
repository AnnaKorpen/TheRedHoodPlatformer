using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/States/PlayerState", order = 51)]
public class PlayerCurrentStateSO : ScriptableObject
{
    [Header("Moving State")]
    public float currentDirection;
    public bool isFacingRight;
    public bool isDashing;

    [Header("Collision Checks")]
    public bool isGrounded;
    public bool isNearGround;
    public bool onWallRight;
    public bool onWallLeft;

    [Header("Control Checks")]
    public bool isControllerOn;
    public bool canMove;
    public bool canJump;
    public bool canDash;
    public bool canAttack;

    [Header("Receiving Damage")]
    public bool isImmuned;
    public Vector3 currentDamageDealer;
}
