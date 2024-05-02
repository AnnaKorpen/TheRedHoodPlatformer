using UnityEngine;

public class ItemInRuntimeSet : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeSetSO itemRuntimeSet;

    private void OnEnable()
    {
        itemRuntimeSet.Add(gameObject);
    }
}
