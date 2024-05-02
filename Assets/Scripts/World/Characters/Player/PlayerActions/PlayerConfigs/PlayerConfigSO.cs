using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/GeneralConfig", order = 51)]
public class PlayerConfigSO : ScriptableObject
{
    public PlayerMovementConfigSO movementConfig;
    public PlayerJumpConfigSO jumpConfig;
    public PlayerGravityConfigSO gravityConfig;
    public PlayerDashConfigSO dashConfig;
    public PlayerCollisionConfigSO collisionConfig;
    public PlayerReactionConfigSO reactionConfig;
}
