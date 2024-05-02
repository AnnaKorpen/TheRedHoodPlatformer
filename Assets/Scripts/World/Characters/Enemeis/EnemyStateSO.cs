using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/States/EnemyState", order = 51)]
public class EnemyStateSO : ScriptableObject
{
    public float currentHealth;
    public bool isImmuned;

    public bool isFacingRight;
    public bool canWalk;
    public EnemyActionState currentActionState;
}
