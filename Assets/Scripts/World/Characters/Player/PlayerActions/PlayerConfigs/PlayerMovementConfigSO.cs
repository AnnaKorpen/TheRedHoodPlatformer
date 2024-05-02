using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/MovementConfig", order = 51)]
public class PlayerMovementConfigSO : ScriptableObject
{
    public float maxMovementSpeed;
    public float moveAcceleration;
    public float moveDecceleration;
}
