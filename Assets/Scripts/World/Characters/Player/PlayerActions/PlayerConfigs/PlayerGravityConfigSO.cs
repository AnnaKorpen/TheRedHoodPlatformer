using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/GravityConfig", order = 51)]
public class PlayerGravityConfigSO : ScriptableObject
{
    public float normalGravityScale;
    public float fallGravityMultiplier;
    public float fastFallGravityMultiplier;
    public float dashEndGravityMultiplier;
    public float maxFallSpeed;
}
