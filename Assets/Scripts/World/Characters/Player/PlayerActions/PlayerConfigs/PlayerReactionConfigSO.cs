using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/ReactionConfig", order = 51)]
public class PlayerReactionConfigSO : ScriptableObject
{
    public Vector2 knockbackForceOnGround;
    public Vector2 knockbackForceInAir;
    public float knockTime;
}
