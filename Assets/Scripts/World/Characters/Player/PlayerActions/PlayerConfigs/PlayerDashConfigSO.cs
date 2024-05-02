using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Configs/PlayerConfig/DashConfig", order = 51)]
public class PlayerDashConfigSO : ScriptableObject
{
    public float dashDistance;
    public float dashSpeed;
    public float dashEndTime;
    public float dashEndSpeed;
    public float dashRefillTime;
}
