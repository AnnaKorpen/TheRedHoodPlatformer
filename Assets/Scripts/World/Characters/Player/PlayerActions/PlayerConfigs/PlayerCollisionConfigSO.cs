using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/CollisionChecks", order = 51)]
public class PlayerCollisionConfigSO : ScriptableObject
{
    public Vector2 groundCollisionCheckSize;
    public Vector2 nearGroundCollisionCheckSize;
    public Vector2 wallCollisionCheckSize;
}
