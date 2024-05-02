using UnityEngine;

public class EnemyPositionForPlayer : MonoBehaviour, IGetPosition
{
    [SerializeField] private PlayerCurrentStateSO playerState;

    public void TakePosition(Vector3 enemyPosition)
    {
        playerState.currentDamageDealer = enemyPosition;
    }
}
