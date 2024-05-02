using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/JumpConfig", order = 51)]
public class PlayerJumpConfigSO : ScriptableObject
{
    public float maxJumpHight;
    public float maxJumpDistance;
}
