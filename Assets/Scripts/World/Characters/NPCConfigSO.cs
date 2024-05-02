using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/NPCConfig", order = 51)]
public class NPCConfigSO : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public float attackForce;
    public float maxDesicionTime;
    public float minDesicionTime;
}
