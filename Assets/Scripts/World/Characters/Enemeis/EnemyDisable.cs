using UnityEngine;


public class EnemyDisable : MonoBehaviour
{
    [SerializeField] private GameObject fantasyPool;

    public void DisableEnemy()
    {
        fantasyPool.transform.parent = transform.parent;

        gameObject.SetActive(false);
    }
}
